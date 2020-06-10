using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerOnLeftOrRight_checker : MonoBehaviour
{
    public bool isPlayerOnLeft;


    private void Start()
    {
        isPlayerOnLeft = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") isPlayerOnLeft = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") isPlayerOnLeft = false;
    }
}
