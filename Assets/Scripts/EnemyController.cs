using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{

    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;

    public float moveSpeed = 5f;
    public float lookRadius = 10f;
    public float rotSpeed = 10f;
    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public float shootRate = 0f;
    public bool shotFired = false;

    public GameObject playerObject;
    public EnemyHealth enemyHealth;

    public static bool isPlayerAlive = true;

    private float shootTimeStamp = 0f;
    
    private Transform monsterTr;
    private Transform target;
    private NavMeshAgent nvAgent;
    private Animator animator;

    


    // Use this for initialization
    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        enemyHealth = GetComponent<EnemyHealth>();

        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            Move();
        }
    }


    // 타겟 바라보기
    void LookAtPlayer()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotSpeed);
    }

    void Attack()
    {
        if (!shotFired)
        {
            if (Time.time > shootTimeStamp)
            {

                //playerObject.GetComponent<Player>().hp -= 10;
                shotFired = true;

                shootTimeStamp = Time.time + shootRate;
            }
        }
        else
        {

        }
    }

    void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            nvAgent.SetDestination(target.position);

            if (distance <= nvAgent.stoppingDistance)
            {
                // Attack the target
                LookAtPlayer();
            }
        }
        else if (distance > nvAgent.stoppingDistance)
        {
            Attack();
        }
        else if (distance > lookRadius)
        {

        }
    }

    void Run()
    {
        if(enemyHealth.currentHP <= 30)
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}