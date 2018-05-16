using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private WeaponStatus weaponStatus;
    private bool isHitted;

	// Use this for initialization
	void Start () {
        weaponStatus = FindObjectOfType<WeaponStatus>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetWeaponDamage
    {
        get
        {
            return weaponStatus.damage;
        }
    }

    public bool IsHitted {
        get
        {
            return isHitted;
        }
    }

        

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isHitted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isHitted = false;
        }
    }
}
