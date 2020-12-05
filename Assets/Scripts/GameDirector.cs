using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject startbt;
    public float DelayTime;
    
    private void Start()
    {
        Invoke("touchinvoke", DelayTime);

        DontDestroyOnLoad(this);
    }
    void touchinvoke()
    {
        startbt.gameObject.SetActive(true);
    }

    public void MoveToStageScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void MoveToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

}
