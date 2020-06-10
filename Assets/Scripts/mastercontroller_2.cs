using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mastercontroller_2 : MonoBehaviour
{
    public GameObject deathCanvas;
    public GameObject ui_canvas;
    public GameObject player, gameCamera;
    AudioSource aSource;
    public AudioClip entry, loop;

    private void Start()
    {
        aSource = gameCamera.GetComponent<AudioSource>();
        PlayAmbient_void();
      
    }
  
  
    public IEnumerator PlayAmbient()
    {
        aSource.clip = entry;
        aSource.loop = false;
        aSource.Play();
        yield return new WaitForSeconds(entry.length);
        aSource.clip = loop;
        aSource.loop = true;
        aSource.Play();
    }
    public void PlayAmbient_void()
    {
        StartCoroutine(PlayAmbient());
    }
    public IEnumerator FadeOutCurrentClip()
    {
        while (aSource.volume > 0)
        {
            aSource.volume -= 0.03f;
            yield return new WaitForSeconds(0.1f);
        }
        aSource.Stop();
        yield break;
    }

    public void RestartOnDeath()
    {      
     SceneManager.LoadScene("Level2");     
    } 
    public void Go_to_mainmenu() //when dead
    {
        deathCanvas.SetActive(false);
        SceneManager.LoadScene("MENU");
    }

}
