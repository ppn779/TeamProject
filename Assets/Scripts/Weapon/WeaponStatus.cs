using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : MonoBehaviour {
    public float range = 2f;
    public float damage = 50f;
    public float attackSpeed = 1.5f;
    public int remainCount = 3;
    public float remainTime = 5f;
    private bool isPlayerEquipped = false;
    private bool isUseful = true;
    private bool isDestroyed = false;
    public bool IsPlayerEquipped
    {
        get { return isPlayerEquipped; }
        set { isPlayerEquipped = value; }
    }
    public bool IsUseful
    {
        get { return isUseful; }
        set { isUseful = value; }
    }
    public bool IsDestroyed
    {
        get { return isDestroyed; }
        set { isDestroyed = value; }
    }

}
