﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystemMng : MonoBehaviour {
    public GameObject player = null;
    //private Enemy[] Enemies = null;

    public GameObject Combo=null;
    private Text ComboText=null;

    private int comboNum=0;

    private const float OFFSET_Y = 130f;                 // 플레이어와의 간격 Y
                                                        // Use this for initialization
    void Start () {
        ComboText = Combo.GetComponent<Text>();
       //Enemies = FindObjectsOfType<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        Follow();

        ComboText.text = "Combo  " + comboNum;
    }

    private void Follow()
    {
        // 월드(World)상에 존재하는 플레이어의 위치를
        // UI가 있는 스크린 좌표로 변환
        Vector2 pos = RectTransformUtility.WorldToScreenPoint(Camera.main, player.transform.position);
        // 간격 적용
        pos.y += OFFSET_Y;
        // 위치 갱신
        ComboText.transform.position = pos;
    }
}


