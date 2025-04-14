using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StageSelectionController : MonoBehaviour
{
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public Button stage4Button;
    public Button stage5Button;

    public GameObject lockedMessagePanel;
    public float messageDisplayDuration = 2.0f;

    void Start()
    {
        // 1번 스테이지: 로딩 씬을 호출하기 전에 target scene을 "GameStage1"로 설정합니다.
        stage1Button.onClick.AddListener(() => {
            PlayerPrefs.SetString("TargetScene", "GameStage1");
            // 로딩 씬으로 전환
            SceneManager.LoadScene("Loading");
        });

        // 나머지 스테이지 버튼: 잠긴 상태에서 메시지를 표시
        stage2Button.onClick.AddListener(ShowLockedMessage);
        stage3Button.onClick.AddListener(ShowLockedMessage);
        stage4Button.onClick.AddListener(ShowLockedMessage);
        stage5Button.onClick.AddListener(ShowLockedMessage);
    }

    void ShowLockedMessage()
    {
        if (lockedMessagePanel != null)
        {
            lockedMessagePanel.SetActive(true);
            StartCoroutine(HideLockedMessageAfterDelay());
        }
    }

    IEnumerator HideLockedMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayDuration);
        lockedMessagePanel.SetActive(false);
    }
}
