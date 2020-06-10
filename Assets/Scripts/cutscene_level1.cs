using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutscene_level1 : MonoBehaviour {

    public GameObject bgCutscene1;
    public GameObject pauseMenu;

    public GameObject dialogueController;
    public GameObject typeWriter;

    public Texture majorPortret;
    public GameObject portrait;//UI object
    private RawImage rawImage;
    


    public AudioClip alarmSound;
    AudioSource aSource;
    public float volume = 1.5f;

    private void Start()
    {
        Invoke("TurnOnBGcutscene1", 7); //sleep time to match with text before
        aSource = GetComponent<AudioSource>();

    }
    void TurnOnBGcutscene1()
    {
        bgCutscene1.SetActive(true);
        aSource.PlayOneShot(alarmSound, volume);
        Invoke("Step2", 5);
    }
    void Step2()
    {
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
        Invoke("FirstType", 0.5f);
        dialogueController.GetComponent<dialogue_global_controller>().NameChange("Major");
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 21;
        rawImage = portrait.GetComponent<RawImage>();
        rawImage.texture = majorPortret;
        

    }
    void FirstType()
    {
        StartCoroutine(typeWriter.GetComponent<typewriter_effect>().ShowText("O chollera... juz jedenasta godzina jest i cale te a ksztofa dalej nie ma. No sami widzicie, on poszedl i juz go dwa dni go nie ma ugulem. "));
    }

}
