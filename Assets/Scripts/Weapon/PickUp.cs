using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    private Inventory inven = null;
	private void Start () {
        inven = this.transform.GetComponent<Inventory>();
        if (inven == null) { this.transform.gameObject.AddComponent<Inventory>(); }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Debug.Log(other.gameObject.name + "아이템을 주웠다");
            inven.AddItem(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
