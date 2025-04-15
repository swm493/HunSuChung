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
        // 1�� ��������: �ε� ���� ȣ���ϱ� ���� target scene�� "GameStage1"�� �����մϴ�.
        stage1Button.onClick.AddListener(() => {
            PlayerPrefs.SetString("TargetScene", "GameStage1");
            // �ε� ������ ��ȯ
            SceneManager.LoadScene("Loading");
        });

        // ������ �������� ��ư: ��� ���¿��� �޽����� ǥ��
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
