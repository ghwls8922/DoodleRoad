using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject startbt;
    public float DelayTime;
    
    private void Start()
    {
        Invoke("touchinvoke", DelayTime);
    }
    void touchinvoke()
    {
        startbt.gameObject.SetActive(true);
    }
}
