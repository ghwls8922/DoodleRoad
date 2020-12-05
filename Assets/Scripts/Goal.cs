using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int currentStageNum = 1;

    public Image goalPanelImage;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentStageNum++;
        if (collision.gameObject.CompareTag("Goal"))
        {
            ShowGoal();
        }
    }

    private void ShowGoal()
    {
        Time.timeScale = 0;
        goalPanelImage.gameObject.SetActive(true);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;

        int nextScene = curScene + 1;

        SceneManager.LoadScene(nextScene);
    }

}
