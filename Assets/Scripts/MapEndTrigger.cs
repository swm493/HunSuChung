using UnityEngine;

public class MapEndTrigger : MonoBehaviour
{
    [SerializeField] private string endingSceneName = "Ending";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManagerEx.Instance.LoadSceneSync(endingSceneName);
        }
    }
}
