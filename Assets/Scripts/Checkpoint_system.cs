using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Checkpoint_system : MonoBehaviour //used to persist data between scenes
{
    private static Checkpoint_system instance;
    private GameObject player;
   
    public Vector2 activeCheckPointPos;

    public GameObject[] currentLevelCheckpoints;

    private string lastSceneName;


    //PERSISTENCE
    int cameras;
    int cups;
    int lives;


    // Start is called before the first frame update
  
    private void Awake()//1st
    {     
        player = GameObject.FindGameObjectWithTag("Player");       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }         
    }    
    public void TurnOffPreviousWPs()
    {
        for (int i = 0; i < currentLevelCheckpoints.Length; i++) //wylacz punkty po lewej od aktywnego
        {
            if (activeCheckPointPos.x > currentLevelCheckpoints[i].transform.position.x)
            {
                currentLevelCheckpoints[i].GetComponent<Checkpoint>().isActive = false;
            }
        }
    }    
    public void SceneReset()
    {
        activeCheckPointPos = new Vector2(currentLevelCheckpoints[0].transform.position.x, currentLevelCheckpoints[0].transform.position.y);
    }

   

    private void Update()
    {
        lastSceneName = SceneManager.GetActiveScene().name;
    }




}
