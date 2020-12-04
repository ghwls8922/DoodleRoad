using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPause;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        _isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if (_isPause == false)
        {
            _isPause = true;
            Time.timeScale = 0;
            panel.SetActive(true);
            return;
        }

        if (_isPause == true)
        {
            _isPause = false;
            Time.timeScale = 1;
            panel.SetActive(false);
            return;
        }
    }
}
