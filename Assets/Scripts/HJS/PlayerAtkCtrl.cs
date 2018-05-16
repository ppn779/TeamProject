using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkCtrl : MonoBehaviour {
    PlayerSpecialAtkCtrl specialAtk=null;

    bool Atk = true;//무기를 들었을때만 true로 바뀌도록 만들 예정

    // Use this for initialization
    void Awake () {
        specialAtk = FindObjectOfType<PlayerSpecialAtkCtrl>();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("Attack");
        }
        if (Input.GetMouseButtonDown(1) && specialAtk.CanSpecialAtk)
        {
            SpecialAtk();
            Debug.Log("필살기 발사");
        }
    }

    public float Attack()//아이템의 공격력 값을 반환시킬 예정(float으로 바꿔도 무방)
                      //공격 애니메이션 bool값 여기서 바꿀 예정.
    {
        if (!specialAtk.CanSpecialAtk)//게이지가 100이 되면 update 함수를 통해 자동으로 canSpecialAtk변수가 true로 바뀌고 필살기로 숫자를 떨어뜨리기 전까지 안 바뀜.
        {
            specialAtk.SpecialAtkGageBarUp();
        }
        return 3.0f;//오류 뜨니깐 그냥 3으로 해놓았음.
    }

    public float SpecialAtk()
    {
        return specialAtk.SpecialAtk();
    }

    public bool CanSpecialAtk()
    {
        return specialAtk.CanSpecialAtk;
    }
}
