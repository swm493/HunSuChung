using UnityEngine;
using UnityEngine.SceneManagement;

public class MapEndTrigger : MonoBehaviour
{
    // 이동할 Ending 씬의 이름 (Build Settings에 해당 씬이 추가되어 있어야 합니다)
    public string endingSceneName = "Ending";

    // Trigger 영역에 진입했을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어 태그가 "Player"인 오브젝트인지 확인
        if (other.CompareTag("Player"))
        {
            // Ending 씬으로 전환
            SceneManager.LoadScene(endingSceneName);
        }
    }
}
