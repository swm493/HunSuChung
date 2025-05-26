using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]    // �� Collider �� Collider2D �� ����
public class TrampolineCollision : MonoBehaviour
{
    [SerializeField] private float launchForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // �ڷ� ƨ�ܳ���
        var rb = other.attachedRigidbody;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.left * launchForce, ForceMode2D.Impulse);
    }
}
