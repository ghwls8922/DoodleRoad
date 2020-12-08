using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public GameObject moveTile;
    public float maxYValue;
    public float speed;

    private Rigidbody2D _rigidbody2D;
    private bool isButtonHit = false;
    private void Start()
    {
        _rigidbody2D = moveTile.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (isButtonHit == true)
        {
            Debug.Log(isButtonHit.ToString());
            if (moveTile.transform.position.y > maxYValue)
            {
                _rigidbody2D.MovePosition(new Vector2(moveTile.transform.position.x, moveTile.transform.position.y) + Vector2.up * Time.fixedDeltaTime);

            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isButtonHit = true;
        Debug.Log("hit!");
        Debug.Log(isButtonHit);
    }
}
