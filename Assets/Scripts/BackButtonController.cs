using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    // Inspector���� Back ��ư�� �Ҵ�
    public Button backButton;

    void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    void OnBackButtonClicked()
    {
        // Ÿ�� ���� Title�� ���� (�� �̸��� ���� Title ���� �̸��� �����ؾ� �մϴ�)
        PlayerPrefs.SetString("TargetScene", "Title");
        // �ε� ������ ��ȯ - �ε� ������ 3�� ���� �ִϸ��̼� �� Title ������ ��ȯ�ϰ� �˴ϴ�.
        SceneManager.LoadScene("Loading");
    }
}
