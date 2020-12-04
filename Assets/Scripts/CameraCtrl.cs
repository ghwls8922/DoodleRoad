using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float moveSpeed;
    
    private Transform transformtoFollow;
    void Start()
    {
        transformtoFollow = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transformtoFollow.position.x + 5, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
    }
}
