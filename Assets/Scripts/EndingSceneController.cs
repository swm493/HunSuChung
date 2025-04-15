using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneController : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 클릭(에디터 및 PC) 또는 모바일 터치 감지
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // 다음에 로드할 씬을 StageSelect로 지정합니다.
            PlayerPrefs.SetString("TargetScene", "StageSelect");

            // 로딩 씬으로 전환합니다.
            SceneManager.LoadScene("Loading");
        }
    }
}
