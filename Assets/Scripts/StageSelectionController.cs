using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectionController : MonoBehaviour
{
    [Header("Stage 1~5 ��ư�� ������� �Ҵ�")]
    public Button[] stageButtons;

    [Header("�� �������� �� �̸� (\"GameStage1\", \"GameStage2\"�� �������)")]
    public string[] stageSceneNames;

    [Header("Stage2~5�� Lock �̹��� (���� = stageButtons.Length - 1)")]
    public GameObject[] lockImages;  // 0��Stage2Lock, 1��Stage3Lock, 2��Stage4Lock, 3��Stage5Lock

    void Start()
    {
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);  // �⺻ 1���� ���

        for (int i = 0; i < stageButtons.Length; i++)
        {
            int stageNumber = i + 1;
            Button btn = stageButtons[i];
            string scene = (stageSceneNames.Length > i) ? stageSceneNames[i] : "";

            btn.onClick.RemoveAllListeners();

            if (unlockedStage >= stageNumber && !string.IsNullOrEmpty(scene))
            {
                // ����� ��������: Ŭ�� ����, �ε��� �� �ش� ���� ��������
                btn.interactable = true;
                btn.onClick.AddListener(() =>
                {
                    PlayerPrefs.SetString("TargetScene", scene);
                    SceneManager.LoadScene("Loading");
                });
            }
            else
            {
                // ��� ��������: ��ư ��Ȱ��ȭ
                btn.interactable = false;
            }

            // Lock �̹��� ��� (Stage2 �̻����)
            if (stageNumber >= 2 && lockImages.Length >= stageNumber - 1)
            {
                // ���� ���̸� �� �ѱ�, ���� �ĸ� �� ����
                lockImages[stageNumber - 2].SetActive(unlockedStage < stageNumber);
            }
        }
    }
}
