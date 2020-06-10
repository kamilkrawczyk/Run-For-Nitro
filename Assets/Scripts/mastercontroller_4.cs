using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mastercontroller_4 : MonoBehaviour
{
    public AudioClip[] trigerrableClips;
    public GameObject gameCamera;

    private AudioSource a_source;
    
    // Start is called before the first frame update
    void Start()
    {
        a_source = gameCamera.GetComponent<AudioSource>();
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Level4");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MENU");
    }
   
    
}
