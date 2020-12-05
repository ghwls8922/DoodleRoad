using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody2D _playerRigidbody2D;
    private Vector3 _jumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _jumpDirection = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump")
        {
            _playerRigidbody2D.AddForce(_jumpDirection * jumpForce, ForceMode2D.Impulse);
        }
    }
}
