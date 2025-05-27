using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 예: 현재 씬을 다시 로드
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
