using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_hitter : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.GetComponent<Player>().BumpOnSpikes();
            player.GetComponent<Player>().Playotaksierobi();
        }
    }
}
