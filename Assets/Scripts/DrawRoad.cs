using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRoad : MonoBehaviour
{
    public float drawableAmount = 1000.0f;

    public GameObject roadPrefab;
    public GameObject currentRoad;

    public List<Vector2> roadPointList;


    LineRenderer _lineRenderer;
    PolygonCollider2D _polygonCollider2D;
    Rigidbody2D _roadRigidbody2D;
    AudioSource _audioSource;
    float _drawTime;

    public void Initialized()
    {
        _roadRigidbody2D = roadPrefab.GetComponent<Rigidbody2D>();
        _roadRigidbody2D.gravityScale = 0;
        _audioSource = GetComponent<AudioSource>();
        _drawTime = 0;
    }

    private void Start()
    {
        Initialized();
    }

    public void DestroyAllTrail()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Road");

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
            
            _drawTime += Time.deltaTime;
            if (_drawTime > 1 && !_audioSource.isPlaying)
            {
                _audioSource.Play();
                _drawTime = 0;
            }

            if (touch.phase == TouchPhase.Began)
            {
                if (drawableAmount >= 0)
                {
                    CreateLine(Camera.main.ScreenToWorldPoint(touch.position));
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
                currentRoad.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else
        {
            _drawTime = 10; //그리기 시작할때 잠시 들리지 않는것을 방지하기 위해
            Debug.Log(_drawTime);
            _audioSource.Stop();
        }
    }

    void CreateLine(Vector2 point)
    {
        currentRoad = Instantiate(roadPrefab, Vector3.zero, Quaternion.identity);

        _lineRenderer = currentRoad.GetComponent<LineRenderer>();
        _polygonCollider2D = currentRoad.GetComponent<PolygonCollider2D>();

        roadPointList.Clear();

        roadPointList.Add(point);
        roadPointList.Add(point);

        _lineRenderer.SetPosition(0, roadPointList[0]);
        _lineRenderer.SetPosition(1, roadPointList[1]);

        _polygonCollider2D.points = roadPointList.ToArray();

    }

    void UpdateLine(Vector2 point)
    {
        roadPointList.Add(point);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
        _polygonCollider2D.points = roadPointList.ToArray();
    }
}
