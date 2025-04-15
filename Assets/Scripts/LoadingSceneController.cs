using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenController : MonoBehaviour
{
    // �ε� �ִϸ��̼ǿ� ����� ���� RectTransform (Inspector���� ����)
    public RectTransform ballTransform;

    // �ִϸ��̼� ���� �ð� (��)
    public float duration = 3f;

    // ���� ���� �� �� ��ġ (Design�� �°� ����)
    public Vector2 startPosition = new Vector2(-500f, 0f);
    public Vector2 endPosition = new Vector2(500f, 0f);

    // �ε��� �� �̸� (�⺻���� StageSelect����, Awake���� PlayerPrefs�� ���)
    private string targetScene = "StageSelect";

    void Awake()
    {
        // Title �Ǵ� StageSelect���� ������ TargetScene �� �о����
        if (PlayerPrefs.HasKey("TargetScene"))
        {
            targetScene = PlayerPrefs.GetString("TargetScene");
        }
    }

    void Start()
    {
        // ���� ���� ��ġ�� ȸ���� �ʱ�ȭ
        if (ballTransform != null)
        {
            ballTransform.anchoredPosition = startPosition;
            ballTransform.localRotation = Quaternion.identity;
            StartCoroutine(AnimateBall());
        }
        else
        {
            // ballTransform�� ������� �ʾҴٸ� �ܼ� ��� �� �� ��ȯ
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator AnimateBall()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // ���� ��ġ ����: ���ۿ��� ������ ���� �̵�
            ballTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            // ���� ȸ��: 0������ -360������ (�ð� �ݴ� ���� ȸ��)
            float angle = Mathf.Lerp(0f, -360f, t);
            ballTransform.localRotation = Quaternion.Euler(0, 0, angle);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // �ִϸ��̼� �Ϸ� �� targetScene���� ��ȯ
        SceneManager.LoadScene(targetScene);
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(targetScene);
    }
}
