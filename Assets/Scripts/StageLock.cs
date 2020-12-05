using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    private int _stage;
    public GameObject stageNumObject;
    // Start is called before the first frame update
    void Start()
    {
        _stage = PlayerPrefs.GetInt("Stage", 0);

        UnityEngine.UI.Button[] stages = stageNumObject.GetComponentsInChildren<UnityEngine.UI.Button>();
        
        for(int i = _stage + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
