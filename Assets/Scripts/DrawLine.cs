using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    int vertexNum = 0;

    EdgeCollider2D edgeCollider2D;

    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        edgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit rayCastHit;

            if (Physics.Raycast(ray, out rayCastHit, 10.0f))
                

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log(rayCastHit.point);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                gameObject.transform.position = rayCastHit.point;

                edgeCollider2D.points[vertexNum] = new Vector2(rayCastHit.point.x,rayCastHit.point.y);
                Debug.Log("collider" + rayCastHit.point);
                vertexNum++;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                StopAllCoroutines();
            }
        }
    }

    IEnumerator MakeCollider(Vector2 point)
    {
        int vertexNum = 0;

        while(true)
        {
            edgeCollider2D.points[vertexNum] = point;

            Debug.Log("collider" + point);
            vertexNum++;

            yield return new WaitForSeconds(0.1f);
        }


    }
}
