using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenController : MonoBehaviour
{
    // 로딩 애니메이션에 사용할 공의 RectTransform (Inspector에서 연결)
    public RectTransform ballTransform;

    // 애니메이션 지속 시간 (초)
    public float duration = 3f;

    // 공의 시작 및 끝 위치 (Design에 맞게 조정)
    public Vector2 startPosition = new Vector2(-500f, 0f);
    public Vector2 endPosition = new Vector2(500f, 0f);

    // 로드할 씬 이름 (기본값은 StageSelect지만, Awake에서 PlayerPrefs로 덮어씀)
    private string targetScene = "StageSelect";

    void Awake()
    {
        // Title 또는 StageSelect에서 지정한 TargetScene 값 읽어오기
        if (PlayerPrefs.HasKey("TargetScene"))
        {
            targetScene = PlayerPrefs.GetString("TargetScene");
        }
    }

    void Start()
    {
        // 공의 시작 위치와 회전을 초기화
        if (ballTransform != null)
        {
            ballTransform.anchoredPosition = startPosition;
            ballTransform.localRotation = Quaternion.identity;
            StartCoroutine(AnimateBall());
        }
        else
        {
            // ballTransform이 연결되지 않았다면 단순 대기 후 씬 전환
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator AnimateBall()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // 공의 위치 보간: 시작에서 끝까지 선형 이동
            ballTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            // 공의 회전: 0도에서 -360도까지 (시계 반대 방향 회전)
            float angle = Mathf.Lerp(0f, -360f, t);
            ballTransform.localRotation = Quaternion.Euler(0, 0, angle);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 애니메이션 완료 후 targetScene으로 전환
        SceneManager.LoadScene(targetScene);
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(targetScene);
    }
}
