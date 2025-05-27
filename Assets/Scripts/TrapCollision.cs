using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public Transform respawnPoint;

    private Transform player;
    private Vector3 initialPos;

    GameObject DieSound;
    AudioSource backmusic;

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
            DieSound = GameObject.Find("PlayerDieSoundManager");
            backmusic = DieSound.GetComponent<AudioSource>();
            backmusic.Play();

            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
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
