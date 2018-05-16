using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float HP = 100.0f;//체력 
    bool die = false;//죽으면 true

    bool Die()
    {
        if (HP <= 0)
            die = true;

        return die;
    }

    public bool isDead
    {
        get
        {
            return die;
        }
    }
}
