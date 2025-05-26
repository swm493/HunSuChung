using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoSingleton<SceneManagerEx>
{
    public string CurrentSceneName { get; private set; }
    public float Progress { get; private set; } = 0f;

    public void LoadSceneSync(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadScene("LoadingScene");
        StartCoroutine(AsyncIEnum(sceneName));
    }

    private IEnumerator AsyncIEnum(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (Progress < 0.99f)
        {
            yield return null;
            Progress = Mathf.Lerp(Progress, op.progress * 10 / 9, 0.01f);
        }

        yield return new WaitForSeconds(1f);
        op.allowSceneActivation = true;
    }
}