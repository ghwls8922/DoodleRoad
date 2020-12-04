using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class touchtoStart : MonoBehaviour
{
    public void touchtostart()
    {
        SceneManager.LoadSceneAsync("TestScenes");
    }
}
