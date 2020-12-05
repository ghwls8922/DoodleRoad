using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    public GameObject moveTile;
    public float maxYValue;
    public float speed;

    private bool isButtonHit = false;

    // Update is called once per frame
    void Update()
    {
        if (isButtonHit == true)
        {
            Debug.Log(isButtonHit.ToString());
            if (moveTile.transform.position.y > maxYValue)
            {
                Debug.Log(isButtonHit.ToString());
                moveTile.transform.Translate(new Vector3(0, speed, 0));
        }   }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isButtonHit = true;
        Debug.Log("hit!");
        Debug.Log(isButtonHit);
    }
}
