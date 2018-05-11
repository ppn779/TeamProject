using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public enum MonsterState { idle, trace, attack, die };

    public MonsterState monsterState = MonsterState.idle;


    public float lookRadius = 10f;

    private Transform monsterTr;
    private Transform target;

    EnemyHealth enemyHealth;

    private NavMeshAgent nvAgent;

    private Animator animator;



    public float traceDist = 10.0f;
    public float attackDist = 2.0f;

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
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            nvAgent.SetDestination(target.position);

            if (distance <= nvAgent.stoppingDistance)
            {
                // Attack the target
                FaceTarget();
            }
        }
    }


    // 타겟 바라보기
    void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 10f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}