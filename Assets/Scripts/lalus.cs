using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class lalus : MonoBehaviour
{
    private GameObject player;
    public GameObject lusterkoToThrow, playerChecker, playerRangeChecker, throwLeftSpot, throwRightSpot, disSprite;
    private Vector3 playerLocation;
    private bool isPlayerOnLeft, isPlayerWithinRange, repeating;
    public LayerMask playerLayer;
    private Animator anim;
    [Header("AudioClips")]
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    [Space]
    public bool isAudioActive = true;
    AudioSource a_source;
    float volume = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("GetPlayerLocation");
        isPlayerOnLeft = true;
        repeating = true;
        anim = GetComponent<Animator>();
      
        a_source = GetComponent<AudioSource>();
        if(isAudioActive)
        {
            StartCoroutine(PlayAudio());
        }
     
    }

    IEnumerator PlayAudio()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            int randomizer = Random.Range(1, 4);
            switch(randomizer)
            {
                case 1:
                    a_source.PlayOneShot(clip1, volume);
                    break;
                case 2:
                    a_source.PlayOneShot(clip2, volume);
                    break;
                case 3:
                    a_source.PlayOneShot(clip3, volume);
                    break;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        isPlayerOnLeft = playerChecker.GetComponent<isPlayerOnLeftOrRight_checker>().isPlayerOnLeft; //get bool is where is the player
        isPlayerWithinRange = playerRangeChecker.GetComponent<CircleCollider2D>().IsTouchingLayers(playerLayer); //is the player within range 
        
        if(repeating)
        {
            if ((isPlayerOnLeft == true) && (isPlayerWithinRange == true)) //player is on the left
            {
                StartCoroutine(ThrowMirror("left"));
                repeating = false;
            }
            else if ((isPlayerOnLeft == false) && (isPlayerWithinRange == true))//is on the right
            {
                StartCoroutine(ThrowMirror("right"));
                repeating = false;
            }      
        }           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            StartCoroutine(Die());
        }
        if(collision.CompareTag("cameraThrown"))
        {
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        player.GetComponent<Player>().PlayJaNieLalus();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Player>().velocity.y += 5;//bump a little
        disSprite.SetActive(true);
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
        yield break;
    }

    IEnumerator GetPlayerLocation() //get player location every second, kurde faja
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            playerLocation = player.transform.position;   
        }
    }

    private IEnumerator ThrowMirror(string direction)//left or right
    {
        while (true)
        {         
            if (direction == "left")
            {
                anim.SetTrigger("left");
                GameObject m1 = Instantiate(lusterkoToThrow, throwLeftSpot.transform.position, throwLeftSpot.transform.rotation);
                m1.GetComponent<lusterko_lalusia>().playerLocation = playerLocation; //przekaz lusterku lokacje ostatnią
                if(!isPlayerOnLeft)
                {
                    repeating = true;
                    yield break;
                }
            }
            else if (direction == "right")
            {
                anim.SetTrigger("right");
                GameObject m2 = Instantiate(lusterkoToThrow, throwRightSpot.transform.position, throwRightSpot.transform.rotation);
                m2.GetComponent<lusterko_lalusia>().playerLocation = playerLocation;
                if (isPlayerOnLeft)
                {
                    repeating = true;
                    yield break;
                }
            }
            yield return new WaitForSeconds(3);
            if (!isPlayerWithinRange)
            {
                repeating = true;
                yield break;
            }
        }    
    }
    public void StopThrow()
    {
        anim.SetTrigger("stopThrow");
    }
   
}
