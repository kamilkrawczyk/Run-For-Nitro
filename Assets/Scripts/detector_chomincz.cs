using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector_chomincz : MonoBehaviour {

    public bool isPlayerNear;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") isPlayerNear = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") isPlayerNear = false;
    }
}
