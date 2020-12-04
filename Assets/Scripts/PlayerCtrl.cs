using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed; // 보통 이동 속도
    public float maxSpeed; // 최대 이동 속도
    public float stopPointX; // 이동 중 퍼즐 구간에 왔을 때
    public float stopDistance; // 퍼즐 구간 거리

    private Rigidbody2D _rigidbody2D;
    private bool isSolved; // 퍼즐을 품
    private int floorY; // 떨어지면 죽는 구간

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        isSolved = false;
        floorY = -10;
    }

    void FixedUpdate()
    {
        if (_rigidbody2D.velocity.x > maxSpeed) // 최대 이동 속도로 속도 고정
            _rigidbody2D.velocity = new Vector2(maxSpeed, _rigidbody2D.velocity.y);

        if (stopPointX < transform.position.x && transform.position.x < stopPointX + stopDistance && !isSolved
        ) // 구간에 도달 했을 때 멈춤
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * 0.5f, _rigidbody2D.velocity.y);
        else
            _rigidbody2D.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        // 대충 문제 풀고 isSolved = true 로 만드는 코드 (SetIsSolved())

        if (transform.position.x > stopPointX + stopDistance) // 다시 이동 시작하고 구간을 벗어나면 다음 퍼즐 준비
            isSolved = false;
        
        if (transform.position.y < floorY)
            Debug.Log("사망"); // 대충 사망 구현 메서드
    }

    // 디버그/테스트용 메서드.
    public void SetIsSolved()
    {
        isSolved = true;
    }
}
