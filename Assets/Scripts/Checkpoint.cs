using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject cS;
    public bool isActive;
   
    // Start is called before the first frame update
    void Start()
    {
        cS = GameObject.FindGameObjectWithTag("CheckPSystem");
        isActive = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isActive)
            {
                cS.GetComponent<Checkpoint_system>().activeCheckPointPos = transform.position; //passes this pos to checkpointer
                cS.GetComponent<Checkpoint_system>().TurnOffPreviousWPs();
            }
           
            //dodac animacje
        }
    }
}
