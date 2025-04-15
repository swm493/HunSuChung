using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneController : MonoBehaviour
{
    void Update()
    {
        // ���콺 ���� Ŭ��(������ �� PC) �Ǵ� ����� ��ġ ����
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // ������ �ε��� ���� StageSelect�� �����մϴ�.
            PlayerPrefs.SetString("TargetScene", "StageSelect");

            // �ε� ������ ��ȯ�մϴ�.
            SceneManager.LoadScene("Loading");
        }
    }
}
