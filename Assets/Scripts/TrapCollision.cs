using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public Transform respawnPoint;

    private Transform player;
    private Vector3 initialPos;

    void Start() // get player's transform
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (respawnPoint == null)
            initialPos = player.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // 위치 이동
        Vector3 targetPos = respawnPoint ? respawnPoint.position : initialPos;
        player.position = targetPos;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
