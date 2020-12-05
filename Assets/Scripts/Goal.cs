using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Goal : MonoBehaviour
{
    public GameObject goalPanel;
    private int _nowStage;
    private int _maxStage;
    
    // Start is called before the first frame update
    void Start()
    {
        int Unit = 1;
        _nowStage = 0;
        goalPanel.SetActive(false);
        _maxStage = PlayerPrefs.GetInt("Stage");
        string _sceneName = SceneManager.GetActiveScene().name;
        _sceneName = Regex.Replace(_sceneName, @"[^0-9]", "");
        for(int i = _sceneName.Length-1; i >= 0; i--)
        {
            _nowStage += Unit * (_sceneName[i] - '0');
            Unit *= 10;
        }
        Debug.Log($"nowStage : {_nowStage}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            if(_maxStage < _nowStage)
            {
                _maxStage = _nowStage;
            }
            PlayerPrefs.SetInt("Stage", _maxStage);
            ShowGoal();
        }
    }

    private void ShowGoal()
    {
        Time.timeScale = 0;
        goalPanel.SetActive(true);
    }
}
