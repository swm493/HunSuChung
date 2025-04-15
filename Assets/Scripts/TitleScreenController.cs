using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // ���� ������
    public Button startButton;
    public Button settingButton;
    public Button quitButton;
    public Button LLMButton;

    // Settings Panel ���� (Inspector���� ����)
    public GameObject settingsPanel;

    // �߰�: CloseButton (Settings Panel�� �ڽ�)
    public Button closeButton;

    void Start()
    {
        // Start, Setting, Quit ��ư �̺�Ʈ �Ҵ�
        startButton.onClick.AddListener(OnStartClicked);
        settingButton.onClick.AddListener(OnSettingClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
        LLMButton.onClick.AddListener(OnLLMClicked);

        // CloseButton �̺�Ʈ �Ҵ�: Settings Panel �ݱ�
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseSettingsPanel);
        }
    }

    void OnStartClicked()
    {
        PlayerPrefs.SetString("TargetScene", "StageSelect");
        // �ε� ������ ��ȯ
        SceneManager.LoadScene("Loading");
    }

    void OnSettingClicked()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OnLLMClicked()
    {
        PlayerPrefs.SetString("TargetScene", "LLM");
        // �ε� ������ ��ȯ
        SceneManager.LoadScene("Loading");
    }

    // CloseButton Ŭ�� �� Settings Panel ��Ȱ��ȭ
    void CloseSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
}
