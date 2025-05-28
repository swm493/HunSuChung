using Define;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void LoadSceneSync(string sceneName)
    {
        SceneManagerEx.Instance.LoadSceneSync(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManagerEx.Instance.LoadSceneAsync(sceneName);
    }
    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SelectCharacterGood()
    {
        GameManager.Instance.LLMCharacter = Character.Assister;
    }

    public void SelectCharacterBad()
    {
        GameManager.Instance.LLMCharacter = Character.Hunter;
    }
}