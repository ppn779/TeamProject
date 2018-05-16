using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpecialAtkCtrl : MonoBehaviour
{
    private const float MAX_GAGE = 200.0f;

    public GameObject specialAtkGageBar = null;

    private RectTransform specialAtkGageBarTr = null;
    private Image specialAtkGageBarImg = null;
    private float specialAtkGage = 0.0f;//필살기 게이지 수치
    private bool canSpecialAtk = false;

    private void Awake()
    {
        specialAtkGageBarTr = specialAtkGageBar.GetComponent<RectTransform>();
        specialAtkGageBarImg = specialAtkGageBar.GetComponent<Image>();
    }

    public bool CanSpecialAtk
    {
        get
        {
            return canSpecialAtk;
        }
    }

    public void SpecialAtkGageBarUp()
    {
        specialAtkGage += 10.0f;
    }

    public float SpecialAtk()
    {
        specialAtkGage = 0.0f;
        return 50.0f;
    }

    private void Update()
    {
        if(specialAtkGage >= MAX_GAGE)
        {
            canSpecialAtk = true;
            specialAtkGage = MAX_GAGE;
        }
        else
        {
            canSpecialAtk = false;
        }

        specialAtkGageBarTr.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, specialAtkGage);

        //색상변화
        Color newColor = specialAtkGageBarImg.color;
        //green,blue 빼서 red만 남게 만들기
        newColor.g -= 1;
        newColor.b -= 1;
        specialAtkGageBarImg.color = newColor;
    }
}
