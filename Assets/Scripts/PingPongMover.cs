using UnityEngine;

public class PingPongMover : MonoBehaviour
{
    [Header("이동 속도")]
    public float speed = 2f;
    [Header("이동 거리 (한쪽 방향)")]
    public float distance = 3f;

    private Vector3 startPos;

    void Start()
    {
        // 시작 위치 저장
        startPos = transform.position;
    }

    void Update()
    {
        // time * speed 값이 0→distance→0→distance… 를 반복
        float x = Mathf.PingPong(Time.time * speed, distance);
        // 시작 위치에서 오른쪽으로 x만큼 이동
        transform.position = startPos + Vector3.right * x;
    }
}
