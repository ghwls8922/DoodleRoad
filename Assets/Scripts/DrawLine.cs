using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawLine : MonoBehaviour
{
    public float drawableAmount = 1000.0f;

    public GameObject roadPrefab;
    public GameObject currentRoad;

    public List<Vector2> roadPointList;


    LineRenderer _lineRenderer;
    EdgeCollider2D _edgeCollider2D;
    Rigidbody2D _roadRigidbody2D;

    PolygonCollider2D _polygonCollider2D;

    public void Initialized()
    {
        _roadRigidbody2D = roadPrefab.GetComponent<Rigidbody2D>();
        _roadRigidbody2D.gravityScale = 0;
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

            if (touch.phase == TouchPhase.Began)
            {
                if (drawableAmount >= 0)
                {
                    CreateLine(touch.position);
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (drawableAmount >= 0)
                {
                    Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(touch.position);

                    if (Vector2.Distance(tempFingerPos, roadPointList[roadPointList.Count - 1]) > 0.1f)
                    {
                        UpdateLine(tempFingerPos);
                        drawableAmount--;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _roadRigidbody2D.gravityScale = 1;

                //DestroyAllTrail();
            }
        }
    }
    
    void CreateLine(Vector2 point)
    {
        currentRoad = Instantiate(roadPrefab, Vector3.zero, Quaternion.identity);

        _roadRigidbody2D.gravityScale = 0;

        _lineRenderer = currentRoad.GetComponent<LineRenderer>();
        //_edgeCollider2D = currentRoad.GetComponent<EdgeCollider2D>();
        _polygonCollider2D = currentRoad.GetComponent<PolygonCollider2D>();

        roadPointList.Clear();

        roadPointList.Add(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
        roadPointList.Add(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));

        _lineRenderer.SetPosition(0, roadPointList[0]);
        _lineRenderer.SetPosition(1, roadPointList[1]);

        //_edgeCollider2D.points = roadPointList.ToArray();
        _polygonCollider2D.points = roadPointList.ToArray();
        currentRoad.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void UpdateLine(Vector2 point)
    {
        roadPointList.Add(point);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
        //_edgeCollider2D.points = roadPointList.ToArray();
        _polygonCollider2D.SetPath(0, roadPointList.ToArray());
    }

}