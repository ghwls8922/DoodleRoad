using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    private static SceneMgr _instance = null;

    private void Awake()
    {
        if(null == _instance)
        {
            _instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SceneMgr Instance
    {
        get
        {
            if(null ==_instance)
            {
                return null;
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivatePausePanel()
    {
        GameObject.FindWithTag("PanelCanvas").transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DeActivatePausePanel()
    {
        GameObject.FindWithTag("PanelCanvas").transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        DeActivatePausePanel();
    }

    public void LoadNumberScene()
    {
        //캔버스 활성화
        GameObject pressedButton = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene("Stage" + pressedButton.transform.GetChild(0).GetComponent<Text>().text);
    }

    public void LoadStageScene()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void LoadNextScene()
    {
        //캔버스 활성화
        Scene scene = SceneManager.GetActiveScene();

        int currentScene = scene.buildIndex;

        int nextScene = currentScene + 1;

        SceneManager.LoadScene(nextScene);
    }
}
