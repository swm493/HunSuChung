using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TrampolineCollision : MonoBehaviour
{
    [SerializeField] private float launchForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var rigidbody = other.attachedRigidbody;
        rigidbody.linearVelocity = Vector2.zero;
        rigidbody.AddForce(Vector2.left * launchForce, ForceMode2D.Impulse);
    }
}
