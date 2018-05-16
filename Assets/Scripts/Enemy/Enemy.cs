using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//실험용

public class Enemy : MonoBehaviour {
    private int hp=100;

    public int beAttacked(int damage)
    {
        return hp -= damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }
}
