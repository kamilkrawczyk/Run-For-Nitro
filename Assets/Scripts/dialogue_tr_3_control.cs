using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_tr_3_control : MonoBehaviour
{

    public GameObject dialogueController;
    public GameObject typewriter;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();       
        Invoke("FirstType", 0.2f);
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 0; //next text
      
    }

    void FirstType()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Uwazaj Panie Majorze! To knur mazurski! Skocz mu na glowe zeby go zabic, lub rzuc kubkiem, ktory wlasnie zebrales klikajac 'J' i jeden z kierunkow poruszania."));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

