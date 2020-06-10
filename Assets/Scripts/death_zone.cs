using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_zone : MonoBehaviour {

    public GameObject _camera;
    private GameObject player;
    public GameObject ui, deathpanel, pausepanel;
    private CameraFollow cameraFollowScript;
    private GameObject backGround;
   

    private void Start()
    {
        cameraFollowScript = _camera.GetComponent<CameraFollow>();
        backGround = GameObject.FindGameObjectWithTag("Background");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Cursor.visible = true;
            player.GetComponent<Player>().PlayOChollera();
            cameraFollowScript.enabled = false;
            ui.SetActive(false);
            deathpanel.SetActive(true);
           
            backGround.GetComponent<BackgroundMover>().enabled = false;
            
            Invoke("DeactivePlayer", 1);


        }
    }
    void DeactivePlayer()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void Update()
    {
      //  if(deathpanel.activeSelf)
     //   {
     //       pausepanel.SetActive(false);
     //       ui.SetActive(false);
     //   }
    }

}
