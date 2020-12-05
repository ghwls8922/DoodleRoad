using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foothold : MonoBehaviour
{
    public float yMax;
    public float yMin;
    public float direction;

    Button button;
    private Vector3 _curPosition;
    // Start is called before the first frame update
    void Start()
    {
        _curPosition = new Vector3(transform.position.x, transform.position.y, 0);
        button = GameObject.Find("Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.isPushed == false)
            button = GameObject.Find("Button").GetComponent<Button>();
       
        if(button.isPushed && _curPosition.y <= yMax)
        {
            _curPosition.y += Time.deltaTime * direction;
            transform.position = _curPosition;
        }
        
    }
}
