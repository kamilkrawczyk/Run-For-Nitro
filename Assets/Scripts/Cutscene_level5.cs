using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_level5 : MonoBehaviour
{
    Animator fadeOutAnimator;
    public GameObject fadeOutObject;
    public GameObject introductionScreen;
    private GameObject player;
    public GameObject dialogueUI;
    public dialogue_global_controller dialController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fadeOutAnimator = fadeOutObject.GetComponent<Animator>();
        StartCoroutine(Level5StartCutscene());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Level5StartCutscene()
    {
        player.GetComponent<Player>().enabled = false;
        fadeOutObject.SetActive(true);
        fadeOutAnimator.enabled = false;
        yield return new WaitForSeconds(1.2f);
        introductionScreen.SetActive(true);
        yield return new WaitForSeconds(6);
        fadeOutAnimator.enabled = true;
        yield return new WaitForSeconds(3);
        dialogueUI.SetActive(true);
        dialController.NameChange("Major");
        dialController.PortraitChange(dialController.portretMaj);
        yield return new WaitForSeconds(.5f);
        dialController.Poczatek5levela();
        yield return null;

    }
}
