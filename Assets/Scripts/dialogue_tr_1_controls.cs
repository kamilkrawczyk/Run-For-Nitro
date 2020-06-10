using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_tr_1_controls : MonoBehaviour {

    public GameObject dialogueController;
    public GameObject typewriter;
    public Texture portretProfesora;
    private RawImage rawimage;
    

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
        rawimage = dialogueController.GetComponent<dialogue_global_controller>().portrait.GetComponent<RawImage>();
        rawimage.texture = portretProfesora;
        dialogueController.GetComponent<dialogue_global_controller>().NameChange("Profesor Tomasz");
        Invoke("FirstType", 0.5f);
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 11; //next text
       // PlayerPrefs.SetInt("HasLvl1BeenStarted", 1); //1 for yes, 0 for no //for removing cutscene
    
      //  PlayerPrefs.Save();
    }

    void FirstType()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Dzien dobry Panie Majorze, tutaj profesor Tomasz; bede twoim przewodnikiem po swiecie Run For Nitro."));        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
