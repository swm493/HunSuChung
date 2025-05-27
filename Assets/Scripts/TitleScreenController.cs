using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // 기존 변수들
    public Button startButton;
    public Button settingButton;
    public Button quitButton;
    public Button LLMButton;

    // Settings Panel 참조 (Inspector에서 연결)
    public GameObject settingsPanel;

    // 추가: CloseButton (Settings Panel의 자식)
    public Button closeButton;

    void Start()
    {
        // Start, Setting, Quit 버튼 이벤트 할당
        startButton.onClick.AddListener(OnStartClicked);
        settingButton.onClick.AddListener(OnSettingClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
        LLMButton.onClick.AddListener(OnLLMClicked);

        // CloseButton 이벤트 할당: Settings Panel 닫기
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseSettingsPanel);
        }
    }

    void OnStartClicked()
    {
        PlayerPrefs.SetString("TargetScene", "StageSelect");
        // 로딩 씬으로 전환
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
        // 로딩 씬으로 전환
        SceneManager.LoadScene("Loading");
    }

    // CloseButton 클릭 시 Settings Panel 비활성화
    void CloseSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
}
