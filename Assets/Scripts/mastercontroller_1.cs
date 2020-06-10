using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class mastercontroller_1 : MonoBehaviour
{
    public GameObject deathCanvas;
    public GameObject ui_canvas;
    AudioSource asource;


    public GameObject cutsceneCanvas; //for level 1 start
    public GameObject player, startpoint, cameraa, background;


    public GameObject checkpoint;

    string sceneName;
    Scene currentScene;


    public void Start()
    {
        //  if (PlayerPrefs.GetInt("HasLvl1BeenStarted") == 1)//if true
        //  {
        // Destroy(cutsceneCanvas);
        // player.GetComponent<Player>().enabled = true;
        //  }
       

        asource = GetComponent<AudioSource>();

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void RestartOnDeath()
    {
       
            SceneManager.LoadScene("Level1");
        
       
        

        /////rest of scenes
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MENU");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayBackGroundMusic()
    {
        asource.Play();
    }
    public void TrunOnCutsceneLv1()//for programmer
    {
        PlayerPrefs.SetInt("HasLvl1BeenStarted", 0);
        PlayerPrefs.Save();
    }






}
