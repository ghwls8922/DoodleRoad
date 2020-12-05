using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ButtonTop에 넣어주시면 됩니다
public class WireButton : MonoBehaviour
{
    private GameObject electricWire;
    private BoxCollider2D bottomCollider;
    private RaycastHit2D raycastHit2D;
    private bool isPushed;
    private int doodlePoint;

    void Start()
    {
        electricWire = GameObject.Find("ElectricWire");
        bottomCollider = GameObject.Find("ButtonBottom").GetComponent<BoxCollider2D>();
        isPushed = false;
    }


    void Update()
    {
        if (isPushed)
        {
            bottomCollider.isTrigger = true;
            electricWire.SetActive(false);
        }
        else
        {
            bottomCollider.isTrigger = false;
            electricWire.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer);
        // 지정된 태그가 달린 것과 버튼이 닿으면 눌림
        if (other.gameObject.layer == 10)
        {
            doodlePoint = 0;
            isPushed = true;
        }
        else
        {
            doodlePoint++;
            if (doodlePoint > 10)
                isPushed = false;
        }
    }
}
