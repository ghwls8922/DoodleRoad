using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalPanel;
    public AudioClip youWin;
    private AudioSource audioSource;
    void Start()
    {
        goalPanel.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
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
        audioSource.clip = youWin;
        audioSource.Play();
    }
}
