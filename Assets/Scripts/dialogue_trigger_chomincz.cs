using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_trigger_chomincz : MonoBehaviour
{
    public GameObject dialogueController;
    public GameObject typewriter;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
            StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText(""));
            Invoke("FirstType", 0.1f);
            dialogueController.GetComponent<dialogue_global_controller>().whichText = 0; //next text

        }   
    }

    void FirstType()
    {
        dialogueController.GetComponent<dialogue_global_controller>().PierwszyRazChomincz();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
