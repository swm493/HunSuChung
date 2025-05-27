using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeCollision : MonoBehaviour
{
    public void OnCollision()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
