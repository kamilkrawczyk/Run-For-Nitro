using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu_controller : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectorPanel;
    public GameObject optionsPanel;
    public GameObject aboutGamePanel;

    

    

    public void Start_lvl_1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Start_lvl_2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Perform_quit()
    {
        Application.Quit();

    }
    public void From_menu_to_selector()
    {
        mainMenuPanel.SetActive(false);
        levelSelectorPanel.SetActive(true);
    }
    public void From_selector_to_menu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectorPanel.SetActive(false);
    }
    public void From_options_to_menu()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void From_menu_to_options()
    {
        optionsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void From_menu_to_aboutGame()
    {
        
        mainMenuPanel.SetActive(false);
        aboutGamePanel.SetActive(true);
        aboutGamePanel.GetComponent<aboutgame_anim_control>().ResetTexture();
        aboutGamePanel.GetComponent<aboutgame_anim_control>().DisableKononAnim();
        aboutGamePanel.GetComponent<aboutgame_anim_control>().StartCorout();
        
    }
    public void From_aboutGame_to_menu()
    {
      
        mainMenuPanel.SetActive(true);
        aboutGamePanel.SetActive(false);
    }
}
