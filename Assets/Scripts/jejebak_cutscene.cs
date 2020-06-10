using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jejebak_cutscene : MonoBehaviour
{
    public GameObject player, ui, dialoguewin, dialogueController;
    // Start is called before the first frame update
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Cursor.visible = true;
            ui.SetActive(false);
            player.GetComponent<Player>().enabled = false;
            dialoguewin.SetActive(true);
            player.GetComponent<Animator>().SetFloat("MoveX", 0);
            dialogueController.GetComponent<dialogue_global_controller>().NameChange("Mario Krzaklewski");
            dialogueController.GetComponent<dialogue_global_controller>().PortraitChange(dialogueController.GetComponent<dialogue_global_controller>().portretMario);
            Invoke("FirstType", 1);
        }    
    }
    void FirstType()
    {
        dialogueController.GetComponent<dialogue_global_controller>().MarioPrzedWalka();
        Destroy(gameObject);
    }
   
}
