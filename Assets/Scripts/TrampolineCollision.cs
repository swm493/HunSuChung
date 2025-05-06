using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]    // ← Collider → Collider2D 로 변경
public class TrampolineCollision : MonoBehaviour
{
    [SerializeField] private float launchForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // 뒤로 튕겨내기
        var rb = other.attachedRigidbody;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.left * launchForce, ForceMode2D.Impulse);
    }
}
