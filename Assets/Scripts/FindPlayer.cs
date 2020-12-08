using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void FindPlayerAndMakeMove()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>().MakePlayerMove();
    }

    
}
