using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_lvl2 : MonoBehaviour
{
    public GameObject canvasToDestroy;

    private void Start() //for playerpref
    {
        if(PlayerPrefs.GetInt("HasLvl2BeenStarted")==1)
        {
            Destroy(canvasToDestroy);
        }
    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("Level2Checkpoint", 1);
    }
    
}
