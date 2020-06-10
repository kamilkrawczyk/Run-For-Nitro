using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nero_cutscene : MonoBehaviour
{
    public GameObject player, ui, dialoguewin, dialogueController, typewriter; 
  
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(false);
            player.GetComponent<Player>().enabled = false;
            dialoguewin.SetActive(true);
            player.GetComponent<Animator>().enabled = false;
            dialogueController.GetComponent<dialogue_global_controller>().NameChange("Nero");
            dialogueController.GetComponent<dialogue_global_controller>().PortraitChange(dialogueController.GetComponent<dialogue_global_controller>().portretNero);
            Invoke("FirstType", 1);
        }
    }
    void FirstType()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("...."));
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 43;       
        Invoke("Die", 3);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
