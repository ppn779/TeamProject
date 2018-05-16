using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
<<<<<<< HEAD
    private Inventory inven = null;
	private void Start () {
        inven = this.transform.GetComponent<Inventory>();
        if (inven == null) { this.transform.gameObject.AddComponent<Inventory>(); }
=======
    private Transform tr = null;
    private Inventory inven = null;
    private Equipment equipment = null;
	private void Start () {
        tr = this.transform;
        inven = tr.GetComponent<Inventory>();
        if (inven == null) { tr.gameObject.AddComponent<Inventory>(); }
        equipment = tr.GetComponent<Equipment>();
        if (equipment == null) { tr.gameObject.AddComponent<Equipment>(); }
>>>>>>> master
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log(collision.gameObject.name + "아이템을 주웠다");
<<<<<<< HEAD
            inven.AddItem(collision.gameObject);
=======
            equipment.Equip(collision.gameObject);
            //inven.AddItem(collision.gameObject);
            
>>>>>>> master
            collision.gameObject.SetActive(false);
        }
    }
}
