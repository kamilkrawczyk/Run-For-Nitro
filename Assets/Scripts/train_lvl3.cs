using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class train_lvl3 : MonoBehaviour
{
    public GameObject showpoint, dispoint, helpPoint, hitter;
    private LayerMask player;
    private bool isShowpointActive, isHelppointActive, beenPlayed;
    private AudioSource aSource;
    public AudioClip horn, riding;

    // Start is called before the first frame update
    void Start()
    {
        player = LayerMask.GetMask("Player");
        isShowpointActive = true;
        isHelppointActive = false;
        aSource = GetComponent<AudioSource>();
        aSource.PlayOneShot(horn, 1);
        beenPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(isShowpointActive)
       {
            if (Vector3.Distance(transform.position, showpoint.transform.position) < 1) //start point
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.layer = 9;
                gameObject.GetComponent<PlatformController>().passengerMask = player;
                if (gameObject.tag == "pociag")
                {
                    hitter.SetActive(true);
                    if(!beenPlayed)
                    {
                        aSource.PlayOneShot(riding, 1);
                        beenPlayed = true;
                    }                
                }
            }
       }
       
        if (Vector3.Distance(transform.position, dispoint.transform.position) < 1)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.layer = 0;
            gameObject.GetComponent<PlatformController>().passengerMask = gameObject.GetComponent<PlatformController>().passengerMask.value = 0;
            isShowpointActive = false;
            isHelppointActive = true;
            beenPlayed = false;
            if(gameObject.tag == "pociag")
            {
                hitter.SetActive(false);
            }
        }
        if(isHelppointActive)
        {          
                if (Vector3.Distance(transform.position, helpPoint.transform.position) < 1)//touch helppoint
                {
                    isShowpointActive = true;
                    isHelppointActive = false;
                if (gameObject.tag == "pociag")
                {                   
                    aSource.PlayOneShot(horn, 1);
                }
            }         
        }
    } 
}
