using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2_to_level3trigger : MonoBehaviour
{
    public GameObject fadeIn;
    private GameObject player;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fadeIn.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            Invoke("GotoLevel3", 2);
            PlayerPrefs.SetInt("HasLevel3BeenUnlocked", 1);
            PlayerPrefs.Save();
        }
    }

    void GotoLeve3()
    {
        SceneManager.LoadScene("Level3");
    }
}
