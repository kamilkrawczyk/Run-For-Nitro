using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gora_knura_collider : MonoBehaviour {

    public GameObject parentEnemy;
    public GameObject checker1;
    public GameObject checker2;
    public GameObject checker3;
    public LayerMask playerLayer;
    public GameObject deathAnimation;
    public GameObject player;
   
    

    private void OnTriggerEnter2D(Collider2D collision) //knur dead
    {
        
        if((collision.tag == "Player") && (IsPlayerAbove()))
        {
           
                int soundRandomizer;
                soundRandomizer = Random.Range(1, 3);
                switch (soundRandomizer)
                {
                    case 1:

                        break;
                    case 2:
                        collision.GetComponent<Player>().PlayJakKurwaZapierdolilem();
                        break;
                    case 3:

                        break;
                }
                deathAnimation.SetActive(true);
                parentEnemy.SetActive(false);
            
        }     
    }

    bool IsPlayerAbove() //check if player is above the knur
    {
        Vector3 direction = Vector3.up;
        float distance = 1.0f;

        RaycastHit2D hit1 = Physics2D.Raycast(checker1.transform.position, direction, distance, playerLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(checker2.transform.position, direction, distance, playerLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(checker3.transform.position, direction, distance, playerLayer);
        if ((hit1.collider != null) || (hit2.collider != null) || (hit3.collider !=null))
        {
            return true;
        }

        return false;
    }
  
  
}
