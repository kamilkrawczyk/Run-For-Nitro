using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goto_level3_from_level2 : MonoBehaviour
{
    public GameObject mainUI;
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
            mainUI.SetActive(false);
            
            
            fadeIn.GetComponent<Animator>().SetInteger("In1Out2", 1);
            fadeIn.GetComponent<Animator>().enabled = true;
            player.GetComponent<Player>().enabled = false;
            Invoke("GotoLevel3", 2);
            PlayerPrefs.SetInt("HasLevel3BeenUnlocked", 1);
            PlayerPrefs.Save();
        }
    }

    void GotoLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
