using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    int hp=100;
    bool canBeAttacked;

    float speed;

    public bool isPlayerNearby
    {
        get
        {
            return canBeAttacked;
        }
    }

    public int beAttacked(int damage)
    {
        return hp -= damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            canBeAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBeAttacked = false;
        }   
    }
}
