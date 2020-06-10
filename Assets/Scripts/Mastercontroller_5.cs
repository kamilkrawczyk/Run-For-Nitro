using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mastercontroller_5 : MonoBehaviour
{
    public GameObject gameCamera;
    private AudioSource aSource;
    public AudioClip ambient;
    // Start is called before the first frame update
    void Start()
    {
        aSource = gameCamera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()
    {
        StartCoroutine(PlayAmbientClip());
    }
    IEnumerator PlayAmbientClip()
    {
        aSource.clip = ambient;
        aSource.loop = true;
        aSource.Play();      
        yield break;
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
        
        SceneManager.LoadScene("MENU");
    }
}
