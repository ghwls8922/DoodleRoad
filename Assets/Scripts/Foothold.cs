using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold : MonoBehaviour
{
    public float yMax;
    public float yMin;
    public float direction;

    private Vector3 _curPosition;

    // Start is called before the first frame update
    void Start()
    {
        _curPosition = new Vector3(transform.position.x, transform.position.y, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        _curPosition.y += Time.deltaTime * direction;
        if(_curPosition.y >= yMax)
        {
            direction *= -1;
            _curPosition.y = yMax;
        }
        else if(_curPosition.y <= yMin)
        {
            direction *= -1;
            _curPosition.y = yMin;
        }
        transform.position = _curPosition; 
    }
}
