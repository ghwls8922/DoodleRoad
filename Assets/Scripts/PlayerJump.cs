using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public AudioClip boing;

    private Rigidbody2D _playerRigidbody2D;
    private Vector3 _jumpDirection;
    private AudioSource _audioSource;

    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        _jumpDirection = new Vector2(0, 1);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            _playerRigidbody2D.AddForce(_jumpDirection * jumpForce, ForceMode2D.Impulse);
            _audioSource.clip = boing;
            _audioSource.Play();
        }
    }
}
