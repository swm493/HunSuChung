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
}