using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mastercontroller_3 : MonoBehaviour
{
   
    public GameObject player, gameCamera;
    private AudioSource aSource;
    public AudioClip ambient_entry, ambient_loop, boss_loop, boss_entry;
    

    string sceneName;
    Scene currentScene;

    private bool startChekingForEnd;



    private void Start()
    {
        aSource = gameCamera.GetComponent<AudioSource>();
        aSource.volume = 0.2f;
        
        
        
    }
 /// <summary>
 /// type in boss or ambient
 /// </summary>
 /// <param name="music"></param>
    public void PlayMusic(string music)//boss or ambient
    {
        if (music == "boss") StartCoroutine(PlayBossMusic());
        else if (music == "ambient") StartCoroutine(PlayAmbientClip());            
    }

    public IEnumerator PlayBossMusic()
    {      
        aSource.clip = boss_entry;
        aSource.loop = false;
        
        aSource.Play();
        yield return new WaitForSeconds(boss_entry.length);
        aSource.clip = boss_loop; aSource.loop = true;
        aSource.Play();
        yield break;
    } 
    public IEnumerator PlayAmbientClip()
    {
        aSource.clip = ambient_entry;
        aSource.loop = false;
        aSource.Play();
        yield return new WaitForSeconds(ambient_entry.length);
        aSource.clip = ambient_loop; aSource.loop = true;
        aSource.Play();
        yield break;
    }
    public IEnumerator FadeOutCurrentClip()
    {
        while(aSource.volume > 0)
        {
            aSource.volume -= 0.03f;
            yield return new WaitForSeconds(0.1f);
        }
        aSource.Stop();
        yield break;
    }
    public void FadeOutInvoke()
    {
        StartCoroutine(FadeOutCurrentClip());       
    }

    public void RestartOnDeath()
    {
        SceneManager.LoadScene("Level3");
    } 
    public void Go_to_mainmenu() //when dead
    {
       // deathCanvas.SetActive(false);
        SceneManager.LoadScene("MENU");
    }



}
