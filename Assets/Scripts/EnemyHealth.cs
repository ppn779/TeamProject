using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startHP = 100;
    public int currentHP;
    public float sinkSpeed = 2.5f;
    public int score = 0;

    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;

    bool isDead = false;
    bool isSinking;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHP = startHP;
    }

    private void Update()
    {
        if (isSinking)
        {

        }
    }

}
