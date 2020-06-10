using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nero_bark_collider : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Player>().DamagePlayer(3.5f);
        }
    }
}
