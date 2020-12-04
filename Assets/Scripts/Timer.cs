using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimeText;    //타이머 출력용 텍스트
    public float GameTime; //타이머, 유니티 안에서 기준시간 선언
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime > 0)
            GameTime -= Time.deltaTime;

        TimeText.text = "Time : " + Mathf.Ceil(GameTime).ToString();
    }
}
