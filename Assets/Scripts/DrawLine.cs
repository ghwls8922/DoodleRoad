using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public float            drawableAmount = 1000.0f;

    public GameObject       trailPrefab;
    public GameObject       currentTrail;

    public List<Vector2>    trailPointList;


    LineRenderer            _lineRenderer;
    EdgeCollider2D          _edgeCollider2D;
    Rigidbody2D             _trailRigidbody2D;

    public void Initialized()
    {
        _trailRigidbody2D = trailPrefab.GetComponent<Rigidbody2D>();
        _trailRigidbody2D.gravityScale = 0;
    }
    
    private void Start()
    {
        Initialized();
    }

    public void DestroyAllTrail()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");

        foreach (GameObject trail in trails)
        {
            Destroy(trail);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit rayCastHit;

            if (Physics.Raycast(ray, out rayCastHit, 10.0f))
                
            if (touch.phase == TouchPhase.Began)
            {
                    if (drawableAmount >= 0) 
                {
                    CreateLine(rayCastHit.point);
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (drawableAmount >= 0)
                {
                    Vector2 tempFingerPos = rayCastHit.point;

                    if (Vector2.Distance(tempFingerPos, trailPointList[trailPointList.Count - 1]) > 0.1f)
                    {
                        UpdateLine(tempFingerPos);
                        drawableAmount--;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                currentTrail.GetComponent<Rigidbody2D>().gravityScale = 1;
                //DestroyAllTrail();
            }
        }
    }

    void CreateLine(Vector2 point)
    {
        currentTrail = Instantiate(trailPrefab, Vector3.zero, Quaternion.identity);

        _lineRenderer = currentTrail.GetComponent<LineRenderer>();
        _edgeCollider2D = currentTrail.GetComponent<EdgeCollider2D>();

        trailPointList.Clear();

        trailPointList.Add(point);
        trailPointList.Add(point);

        _lineRenderer.SetPosition(0, trailPointList[0]);
        _lineRenderer.SetPosition(1, trailPointList[1]);

        _edgeCollider2D.points = trailPointList.ToArray();

    }

    void UpdateLine(Vector2 point)
    {
        trailPointList.Add(point);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
        _edgeCollider2D.points = trailPointList.ToArray();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
    