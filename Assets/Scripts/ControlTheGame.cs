using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlTheGame : MonoBehaviour {

    public GameObject deathCanvas;
    public GameObject ui_canvas;


    public GameObject cutsceneCanvas; //for level 1 start
    public GameObject player;

    string sceneName;
    Scene currentScene;



    public void Start()
    {
        if (PlayerPrefs.GetInt("HasLvl1BeenStarted") == 1)//if true
        {
            Destroy(cutsceneCanvas);
            player.GetComponent<Player>().enabled = true;
        }

      

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;


        
    }

    public void RestartOnDeath()
    {
        if (sceneName == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        if (sceneName == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }

        /////rest of scenes
    }











    public void Reload_lvl_1_onDeatch()
    {
        deathCanvas.SetActive(false);
        ui_canvas.SetActive(true);
        SceneManager.LoadScene("Level1");
    }
    public void Go_to_mainmenu() //when dead
    {
        deathCanvas.SetActive(false);
        SceneManager.LoadScene("MENU");
    }



} 
