using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene_level4 : MonoBehaviour
{
    public Animator fadeOutAnimator;
    public GameObject fadeOutObject;
    public GameObject introductionScreen;
    private GameObject player;
    public GameObject dialogueUI;
    public dialogue_global_controller dialController;
    AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aSource = GetComponent<AudioSource>();
        aSource.loop = false;
        StartCoroutine(Level4StartCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Level4StartCutscene()
    {
        player.GetComponent<Player>().enabled = false;
        fadeOutObject.SetActive(true);
        fadeOutAnimator.enabled = false;
        yield return new WaitForSeconds(1.2f);
        introductionScreen.SetActive(true);
        yield return new WaitForSeconds(7);
        fadeOutAnimator.enabled = true;
        yield return new WaitForSeconds(4);
        aSource.Play();
        yield return new WaitForSeconds(2);
        dialogueUI.SetActive(true);
        dialController.NameChange("Major");
        dialController.PortraitChange(dialController.portretMaj);
        yield return new WaitForSeconds(.5f);
        dialController.PoczatekKsiezyca();
        yield break;
        //zmienic pref na odegrana cutscene

    }
}
