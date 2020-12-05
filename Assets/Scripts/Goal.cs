using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalPanel;
    // Start is called before the first frame update
    void Start()
    {
        goalPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            ShowGoal();
        }
    }

    private void ShowGoal()
    {
        Time.timeScale = 0;
        goalPanel.SetActive(true);
    }
}
