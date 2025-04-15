using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    // Inspector에서 Back 버튼을 할당
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
        // 타겟 씬을 Title로 지정 (씬 이름은 실제 Title 씬의 이름과 동일해야 합니다)
        PlayerPrefs.SetString("TargetScene", "Title");
        // 로딩 씬으로 전환 - 로딩 씬에서 3초 동안 애니메이션 후 Title 씬으로 전환하게 됩니다.
        SceneManager.LoadScene("Loading");
    }
}
