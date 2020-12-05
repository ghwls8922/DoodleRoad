using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ButtonTop에 넣어주시면 됩니다
public class WireButton : MonoBehaviour
{
    private GameObject _electricWire;
    private BoxCollider2D _bottomCollider;
    private RaycastHit2D _raycastHit;
    private bool _isPushed;
    private int _doodlePoint;

    void Start()
    {
        _electricWire = GameObject.Find("ElectricWire");
        _bottomCollider = GameObject.Find("ButtonBottom").GetComponent<BoxCollider2D>();
        _isPushed = false;
    }


    void Update()
    {
        if (_isPushed)
        {
            _bottomCollider.isTrigger = true;
            _electricWire.SetActive(false);
        }
        else
        {
            _bottomCollider.isTrigger = false;
            _electricWire.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer);
        // 지정된 태그가 달린 것과 버튼이 닿으면 눌림
        if (other.gameObject.layer == 10)
        {
            _doodlePoint = 0;
            _isPushed = true;
        }
        else
        {
            _doodlePoint++;
            if (_doodlePoint > 10)
                _isPushed = false;
        }
    }
}
