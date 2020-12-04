using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        

        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, transform.position + new Vector3(0, 10, 0));

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Start");
            }

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log(touch.deltaPosition);
            }

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch End");
            }
        }
    }
}
