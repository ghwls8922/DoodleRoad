using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimeText;    //타이머 출력용 텍스트
    public float GameTime; //타이머, 유니티 안에서 기준시간 선언
    public GameObject player;
    public GameObject gameOver;
    private AudioSource audioSource;
    
    void Start()
    {
        gameOver.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameTime > 0)
            GameTime -= Time.deltaTime;

        if(GameTime <= 0)
        {
            Destroy(player);
            Time.timeScale = 0;
            gameOver.SetActive(true);
            audioSource.Play();
        }

        TimeText.text = "Time : " + Mathf.Ceil(GameTime).ToString();
    }
}