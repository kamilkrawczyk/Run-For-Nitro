using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goto_level2_from_level1_trigger : MonoBehaviour {

    public GameObject fadeIn;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fadeIn.SetActive(true);
            fadeIn.GetComponent<Animator>().SetInteger("In1Out2", 1);
            Invoke("GotoLevel2", 4);


           // PlayerPrefs.SetInt("HasLevel2BeenUnlocked", 1);
           // PlayerPrefs.Save();
        }
    }

    void GotoLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
   
   
}
