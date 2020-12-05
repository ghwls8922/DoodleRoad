using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float moveSpeed;
    
    private Transform _transformtoFollow;
    void Start()
    {
        _transformtoFollow = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(_transformtoFollow.position.x + 5, _transformtoFollow.position.y, transform.position.z), moveSpeed * Time.deltaTime);
    }
}
