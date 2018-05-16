using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    private Inventory inven = null;
	private void Start () {
        inven = this.transform.GetComponent<Inventory>();
        if (inven == null) { this.transform.gameObject.AddComponent<Inventory>(); }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log(collision.gameObject.name + "아이템을 주웠다");
            inven.AddItem(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
