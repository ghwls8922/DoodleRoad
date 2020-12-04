using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유정민 작성
public class PlayerCtrl : MonoBehaviour
{
    public int moveSpeed; // 보통 이동 속도
    public int maxSpeed; // 최대 이동 속도
    public int stopPointX; // 이동 중 퍼즐 구간에 왔을 때
    public int stopDistance; // 퍼즐 구간 거리

    private Rigidbody2D rigidbody;
    private bool isSolved; // 퍼즐을 품

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isSolved = false;
    }

    void Update()
    {
        if (rigidbody.velocity.x > maxSpeed) // 최대 이동 속도로 속도 고정
            rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y);

        if (stopPointX < transform.position.x && transform.position.x < stopPointX + stopDistance && !isSolved)
        {
            // 구간에 도달 했을 때 멈춤
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * 0.1f, rigidbody.velocity.y);
        }
        else
            rigidbody.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);


        // 대충 문제 풀고 isSolved = true 로 만드는 코드 (SetIsSolved())

        if (transform.position.x > stopPointX + stopDistance) // 다시 이동 시작하고 구간을 벗어나면 다음 퍼즐 준비
            isSolved = false;
    }
    
    // 디버그/테스트용 메서드.
    public void SetIsSolved()
    {
        isSolved = true;
    }
}
