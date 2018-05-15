using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersStatusMng : MonoBehaviour {
    //private Player player;
    private Enemy enemy;
    public Text enemyHP;

    int eHP=100;//실험용

	// Use this for initialization
	void Start () {
        //player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)&&enemy.isPlayerNearby)
        {
            //eHP= enemy.beAttacked(player.Attack());
        }

        enemyHP.text = "EnemyHP = " + eHP;
    }
}
