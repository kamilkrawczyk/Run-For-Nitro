using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pause_menu_ui;
    public GameObject game_ui;
    public GameObject slider;
   
  

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        AudioListener.volume = slider.GetComponent<Slider>().value;
    }

    public void Resume()
    {
        pause_menu_ui.SetActive(false);
        game_ui.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pause_menu_ui.SetActive(true);
        game_ui.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
