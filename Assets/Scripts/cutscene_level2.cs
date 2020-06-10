using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class cutscene_level2 : MonoBehaviour //if this object is actuve, starting cutscene will play
{
    public GameObject bgCutscene1;
    public GameObject dialogueUI;

    public GameObject dialogueController;
    public GameObject typeWriter;

   
   
   

    public GameObject background;
    public GameObject ladderPos1, ladderPos2;

    private GameObject player;

   


    private void Start()
    {
        Invoke("TurnOnBGcutscene1", 6); //sleep time to match with text before
        player = GameObject.FindGameObjectWithTag("Player");

}
    void TurnOnBGcutscene1()
    {
        bgCutscene1.SetActive(true);      
        Invoke("Step2", 2);
    }
    void Step2()
    {
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
        Invoke("FirstType", 0.5f);       
        dialogueController.GetComponent<dialogue_global_controller>().PortraitChange(dialogueController.GetComponent<dialogue_global_controller>().portretMex);
        dialogueController.GetComponent<dialogue_global_controller>().NameChange("Czarny");
       
    }
    void FirstType()
    {
        dialogueController.GetComponent<dialogue_global_controller>().FirstTypeLvl2_start();
    }

    public void WalkLadder()
    {
        background.GetComponent<Animator>().SetInteger("In1Out2", 2);
        background.GetComponent<Animator>().Play(0);
        player.transform.position = ladderPos1.transform.position;              
        Invoke("WalkLadder2", 1);
    }
    void WalkLadder2()
    {
        startWalking = true;
    }
    bool startWalking, st1;
    float speed = 1;
    private void Update()
    {
        float step = speed * Time.deltaTime;

        if(startWalking) //jeszcze odtworzyc animacje
        {
            if(player.transform.position != ladderPos2.transform.position)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, ladderPos2.transform.position, step);
            }
            else//zszedl
            {
                if(!st1)
                {
                    dialogueUI.SetActive(true);
                    dialogueController.GetComponent<dialogue_global_controller>().TypeMajorUStopDrabiny();
                    startWalking = false;
                    st1 = true;
                }
             
            }
                
                
            
        }
    }
    



}
