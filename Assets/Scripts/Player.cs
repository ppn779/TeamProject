using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int HP = 100;//체력
    float specialAtkGage = 0.0f;//필살기 게이지 수치    
    float speed = 6.0f;//속도

    bool Atk;
    bool die = false;

    Vector3 movement; //GetAxisRaw 처리 다음에 반환값을 담을 변수                 
    Animator playerAnim;                     
    Rigidbody playerRigidbody;          
    int floorMask; //raycast Layer 정보를 담을 변수                    
    float camRayLength = 100f; //raycast 거리 값 

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");//"Floor"로 layer 위치값 등록

        playerAnim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if(!Die())//죽었을때 처리들을 담을 함수. 애니메이션 효과 넣을 예정
        {
            float h = Input.GetAxisRaw("Horizontal");//가로 값
            float v = Input.GetAxisRaw("Vertical");//세로 값

            Move(h, v);
            Turning();
            Animating(h, v);
        }
    }

    bool Die()
    {
        if (HP <= 0)
            die = true;

        return die;
    }

    void Move(float h, float v)
    {
        //방향 값 담음.
        movement.Set(h, 0f, v);

        //정규화 처리
        movement = movement.normalized * speed * Time.deltaTime;

        //물리 처리 이후 캐릭터 이동
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //카메라에서 마우스 포지션으로 Ray 발사
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

       
        RaycastHit floorHit;

       
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
           //플레이어와 마우스의 거리 값 구함.
            Vector3 playerToMouse = floorHit.point - transform.position;

            //Y는 변함 없으므로 0 처리
            playerToMouse.y = 0f;

            //플레이어 위치에서 마우스 위치로의 방향 값 구하고 저장
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //저장한 방향 값으로 물리 처리 이후 회전
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        //방향키 있으면 ||연산자에 의해 1이 반환되어서 true, 방향키 없으면 false 반환 됨.
        bool walking = h != 0f || v != 0f;

        //저장된 bool값 들어감.
        playerAnim.SetBool("IsWalking", walking);
    }

    public int Attack()//아이템의 공격력 값을 반환시킬 예정(float으로 바꿔도 무방)
        //공격 애니메이션 bool값 여기서 바꿀 예정.
    {
        return 3;//오류 뜨니깐 그냥 3으로 해놓았음.
    }

    public bool isDead
    {
        get
        {
            return die;
        }
    }
}
