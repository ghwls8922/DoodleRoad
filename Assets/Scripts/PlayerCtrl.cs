using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed; // 보통 이동 속도
    public float maxSpeed; // 최대 이동 속도
    public float stopPointX; // 이동 중 퍼즐 구간에 왔을 때
    public float stopDistance; // 퍼즐 구간 거리
    public AudioClip youLose;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private RaycastHit2D _raycastHit2D;
    private AudioSource _audioSource;
    private bool _isSolved; // 퍼즐을 품
    private int _floorY; // 떨어지면 죽는 구간
    private Vector2 _moveDirection; // 움직이는 방향
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _isSolved = false;
        _floorY = -10;
        _moveDirection = Vector2.right;
    }

    void FixedUpdate()
    {
        // 최대 이동 속도로 속도 고정 (이동 방향에 따라 다른 최대 속도)
        if (Mathf.Abs(_rigidbody2D.velocity.x) > maxSpeed)
        {
            _rigidbody2D.velocity = new Vector2(maxSpeed * _moveDirection.x, _rigidbody2D.velocity.y);
        }

        // 구간에 도달 했을 때 멈춤
        if (stopPointX < transform.position.x && transform.position.x < stopPointX + stopDistance && !_isSolved)
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * 0.5f, _rigidbody2D.velocity.y);
        else
            _rigidbody2D.AddForce(_moveDirection * moveSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        // 대충 문제 풀고 isSolved = true 로 만드는 코드 (SetIsSolved())

        // 다시 이동 시작하고 구간을 벗어나면 다음 퍼즐 준비
        if (transform.position.x > stopPointX + stopDistance) 
            _isSolved = false;

        Debug.DrawRay(transform.position, _moveDirection, Color.red);
        _raycastHit2D = Physics2D.Raycast(transform.position, _moveDirection, 
                2, LayerMask.GetMask("Ground"));
        
        if (_raycastHit2D.collider != null)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * 0.3f, _rigidbody2D.velocity.y);
            _moveDirection *= -1;
        }
        
        // 대충 사망 구현 메서드
        if (transform.position.y < _floorY)
        {
            Debug.Log("사망");
            _audioSource.clip = youLose;
            _audioSource.Play();
            gameObject.SetActive(false);
        }

    }

    // 디버그/테스트용 메서드.
    public void SetIsSolved()
    {
        _isSolved = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 11)
        {
            Debug.Log("사망");
            _audioSource.clip = youLose;
            _audioSource.Play();
            gameObject.SetActive(false);

        }
    }
}
