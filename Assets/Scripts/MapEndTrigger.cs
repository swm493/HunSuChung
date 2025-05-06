using UnityEngine;
using UnityEngine.SceneManagement;

public class MapEndTrigger : MonoBehaviour
{
    // �̵��� Ending ���� �̸� (Build Settings�� �ش� ���� �߰��Ǿ� �־�� �մϴ�)
    public string endingSceneName = "Ending";

    // Trigger ������ �������� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾� �±װ� "Player"�� ������Ʈ���� Ȯ��
        if (other.CompareTag("Player"))
        {
            // Ending ������ ��ȯ
            SceneManager.LoadScene(endingSceneName);
        }
    }
}
