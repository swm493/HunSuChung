using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectionController : MonoBehaviour
{
    [Header("Stage 1~5 버튼을 순서대로 할당")]
    public Button[] stageButtons;

    [Header("각 스테이지 씬 이름 (\"GameStage1\", \"GameStage2\"… 순서대로)")]
    public string[] stageSceneNames;

    [Header("Stage2~5용 Lock 이미지 (길이 = stageButtons.Length - 1)")]
    public GameObject[] lockImages;  // 0→Stage2Lock, 1→Stage3Lock, 2→Stage4Lock, 3→Stage5Lock

    void Start()
    {
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);  // 기본 1번만 언락

        for (int i = 0; i < stageButtons.Length; i++)
        {
            int stageNumber = i + 1;
            Button btn = stageButtons[i];
            string scene = (stageSceneNames.Length > i) ? stageSceneNames[i] : "";

            btn.onClick.RemoveAllListeners();

            if (unlockedStage >= stageNumber && !string.IsNullOrEmpty(scene))
            {
                // 언락된 스테이지: 클릭 가능, 로딩씬 → 해당 게임 스테이지
                btn.interactable = true;
                btn.onClick.AddListener(() =>
                {
                    PlayerPrefs.SetString("TargetScene", scene);
                    SceneManager.LoadScene("Loading");
                });
            }
            else
            {
                // 잠긴 스테이지: 버튼 비활성화
                btn.interactable = false;
            }

            // Lock 이미지 토글 (Stage2 이상부터)
            if (stageNumber >= 2 && lockImages.Length >= stageNumber - 1)
            {
                // 해제 전이면 락 켜기, 해제 후면 락 끄기
                lockImages[stageNumber - 2].SetActive(unlockedStage < stageNumber);
            }
        }
    }
}
