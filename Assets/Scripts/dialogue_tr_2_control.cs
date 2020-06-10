using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_tr_2_control : MonoBehaviour {

    public GameObject dialogueController;
    public GameObject typewriter;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText(""));
        Invoke("FirstType", 0.1f);
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 0; //next text
       
    }

    void FirstType()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Panie Majorze! Znalazl Pan starozytny artefakt Kargula: paczke z gownem! Gratulacje!"));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
