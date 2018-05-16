using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookRadius = 10f;
    public float rotSpeed = 10f;
    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public float shootRate = 1f;

    public float stayTime = 0f;

    public int hp = 10;
    public bool isDeath = false;

    //public bool shotFired = false;

    public Vector3 startPos;
    public Vector3 targetPos;

    //public GameObject playerObject;
    public static bool isPlayerAlive = true;



    private Transform monsterTr;
    private Transform target;

    EnemyHealth enemyHealth;

    [SerializeField] private NavMeshAgent nvAgent;
    [SerializeField] private Animator animator;

    private float shootTimeStamp = 0f;


    private void Awake()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        enemyHealth = GetComponent<EnemyHealth>();

        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
        attackDist = nvAgent.stoppingDistance;
        nvAgent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            EnemyAI();
        }
    }

    // 타겟 바라보기
    void LookAtPlayer()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotSpeed);
    }

    void EnemyAI()
    {
        if (isPlayerAlive)
        {
            Move();
        }
        else
        {
            if (Time.deltaTime > 3f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        float speed = MoveCheck();

        animator.SetFloat("speed", speed);

        if (distance <= lookRadius)
        {
            nvAgent.SetDestination(target.position);
            LookAtPlayer();

            Debug.Log("Target DIST" + distance);
            Debug.Log("ATK DIST" + attackDist);

            if (distance <= attackDist)
            {
                Attack();
            }
            else
            {

            }
        }

        else if (distance > lookRadius)
        {
            nvAgent.SetDestination(targetPos);
            Patrolling();
        }

    }

    void Attack()
    {
        shootTimeStamp += Time.deltaTime;

        if (shootTimeStamp >= shootRate)
        {
            animator.SetTrigger("attack");
            shootTimeStamp = 0f;
        }
    }

    private float MoveCheck()
    {
        float aniSpeed;
        aniSpeed = Vector3.Project(nvAgent.desiredVelocity, transform.forward).magnitude;

        return aniSpeed;
    }

    void Patrolling()
    {
        float speed = MoveCheck();

        if (speed <= 0f)
        {
            stayTime += Time.deltaTime;
            if (stayTime > 3f)
            {
                Vector3 rePos = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                targetPos = startPos + rePos;
                nvAgent.SetDestination(targetPos);
                stayTime = 0f;
            }
        }
    }



    void Run()
    {
        if (enemyHealth.currentHP <= 30)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //hp -= damage;
        if (hp <= 0)
        {
            animator.SetTrigger("die");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}