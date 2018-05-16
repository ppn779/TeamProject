using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : MonoBehaviour {
    private Inventory inventory=null;
    private GameObject weapon = null;
    private PlayerAtkCtrl playerAtkCtrl = null;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        playerAtkCtrl = FindObjectOfType<PlayerAtkCtrl>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = inventory.EquipItem(0);
            if (weapon)
            {
                playerAtkCtrl.CanAtk = true;
                Debug.Log("무기 장착");
            }
        }
    }
}
