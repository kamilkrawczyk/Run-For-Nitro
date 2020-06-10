using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene_level3 : MonoBehaviour
{
    public GameObject mainUI, introduceText, dialogueUI, dialogueController, fadeOut;
    private GameObject player;

    private dialogue_global_controller dialogue_controller;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogue_controller = dialogueController.GetComponent<dialogue_global_controller>();
        fadeOut.SetActive(true);
        

        mainUI.SetActive(false);
        player.GetComponent<Player>().enabled = false;
        

        StartCoroutine(EventRoutine());
    }
    IEnumerator EventRoutine()
    {
        yield return new WaitForSeconds(1);
        introduceText.SetActive(true); //napis
        yield return new WaitForSeconds(5);
        fadeOut.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        dialogueUI.SetActive(true);      
        dialogue_controller.NameChange("Major");
        dialogue_controller.PortraitChange(dialogue_controller.portretMaj);
        yield return new WaitForSeconds(.5f);
        dialogue_controller.VeryStartTrzeciegoLevela();
        Cursor.visible = true;
        yield return null;
    }

  
}
