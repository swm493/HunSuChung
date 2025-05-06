using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectionController : MonoBehaviour
{
    [Header("Stage Select Buttons")]
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public Button stage4Button;
    public Button stage5Button;

    void Start()
    {
        stage1Button.onClick.AddListener(() => LoadWithLoading("GameStage1"));
        stage2Button.onClick.AddListener(() => LoadWithLoading("GameStage2"));
        stage3Button.onClick.AddListener(() => LoadWithLoading("GameStage3"));
        stage4Button.onClick.AddListener(() => LoadWithLoading("GameStage4"));
        stage5Button.onClick.AddListener(() => LoadWithLoading("GameStage5"));
    }

    private void LoadWithLoading(string targetSceneName)
    {
        // 타겟 씬 이름 저장
        PlayerPrefs.SetString("TargetScene", targetSceneName);
        PlayerPrefs.Save();

        // 기존 로딩 씬으로 이동
        SceneManager.LoadScene("Loading");
    }
}
