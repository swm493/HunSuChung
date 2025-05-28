using UnityEngine;
using UnityEngine.Events;

public class SituationTrigger : MonoBehaviour
{
    public string situation;
    public UnityEvent<string> OnSituation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnSituation?.Invoke(situation);
        }
    }
}