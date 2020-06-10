using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level5_end_trigger : MonoBehaviour
{
    public GameObject fadeIn;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            fadeIn.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<Animator>().SetTrigger("Idle");
            Invoke("LoadNextLevel", 2);
        }
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level6");
    }
}
