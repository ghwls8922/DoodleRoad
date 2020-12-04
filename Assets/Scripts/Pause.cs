using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _isPause;
    
    // Start is called before the first frame update
    void Start()
    {
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
            Time.timeScale = 0;
            _isPause = true;
            return; 
        }

        if (_isPause == true)
        {
            Time.timeScale = 1;
            _isPause = false;
            return;
        }
    }
}
