using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkCtrl : MonoBehaviour {
    private PlayerSpecialAtkCtrl specialAtkCtrl=null;
    private bool canAtk = false;//무기를 들었을때만 true로 바뀌도록 만들 예정
    //어택 컨트롤러가 웨폰의 정보를 가지고 조종하는게 맞다고 생각함.
    private Weapon weapon=null;

    // Use this for initialization
    void Awake () {
        specialAtkCtrl = FindObjectOfType<PlayerSpecialAtkCtrl>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&canAtk)
        {
            Attack();
            if (!specialAtkCtrl.CanSpecialAtk&&weapon.IsHitted)//게이지가 100이 되면 update 함수를 통해 자동으로 canSpecialAtk변수가 true로 바뀌고 필살기로 숫자를 떨어뜨리기 전까지 안 바뀜.
            {
                specialAtkCtrl.SpecialAtkGageBarUp();
            }
        }
        if (Input.GetMouseButtonDown(1) && specialAtkCtrl.CanSpecialAtk)
        {
            SpecialAtk();
            Debug.Log("필살기 발사");
        }
    }

    public bool CanAtk
    {
        get
        {
            return canAtk;
        }
        set
        {
            canAtk = value;
        }
    }

    public float Attack()//아이템의 공격력 값을 반환시킬 예정(float으로 바꿔도 무방)
                      //공격 애니메이션 bool값 여기서 바꿀 예정.
    {
        return weapon.GetWeaponDamage;
    }

    public float SpecialAtk()
    {
        return specialAtkCtrl.SpecialAtk();
    }

    public bool CanSpecialAtk()
    {
        return specialAtkCtrl.CanSpecialAtk;
    }
}
