using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolce_skrypt : MonoBehaviour {

    private GameObject player;
  
    private Player playerScript;
    

	// Use this for initialization
	void Start () {
      
        player = GameObject.FindGameObjectWithTag("Player");
       
        playerScript = player.GetComponent<Player>();
    }
	
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerScript.DamagePlayer(5);
                    playerScript.PlayDobrzeZeKupilem();
            
        }    
    }
}
