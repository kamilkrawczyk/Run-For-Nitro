using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kibel_trigger : MonoBehaviour
{
    public GameObject _animation;
    public GameObject points;
    public GameObject dialogueController, typewriter;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animation.SetActive(true);
        points.SetActive(true);
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();  
        Invoke("FirstType", 0.3f);        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        //dodac playerpref ze juz znalezione
    }

    void FirstType()
    {
        dialogueController.GetComponent<dialogue_global_controller>().MexykKibelLvl2();
    }
}
