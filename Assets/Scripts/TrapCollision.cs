using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ��: ���� ���� �ٽ� �ε�
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
