using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class knur_controller : MonoBehaviour
{
    public float speed = 0.0001f;
    private bool movingLeft;
    private bool movingRight;
    private bool noDirection;
    private bool stopMoving;
    private int framesToWait = 60;
    private int framesCounter =0;

    public GameObject parentToDestroy;


    public GameObject waypoint1; // left one!
    public GameObject waypoint2; // right one!

    public Animator anim;

    private Transform t1; //transfors for waypoints
    private Transform t2;

    AudioSource aSource;
    public float volume = 8;
    public AudioClip chrum1;
    public AudioClip chrum2;
    public AudioClip chrum3;
    public AudioClip death;

    private GameObject player;
    public GameObject deathAnimation;

   



    void Start()
    {
        t1 = waypoint1.GetComponent<Transform>();
        t2 = waypoint2.GetComponent<Transform>();
        noDirection = true;
        movingLeft = false;
        movingRight = false;
        player = GameObject.FindGameObjectWithTag("Player");
        aSource = GetComponent<AudioSource>();
        InvokeRepeating("ChrumRepeater", 2, 5);

    }

    void Update()
    {
        ////////////////////////PATROL//////////////////////////////
        float step = speed * Time.deltaTime;

        if (!stopMoving)
        {
            if (noDirection == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, t1.position, step / 2); // divide to change speed
                if (transform.position == t1.position)
                {
                    noDirection = false;
                    movingRight = true;
                }
            }
            if (movingRight == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, t2.position, step / 2);
                if (transform.position == t2.position)
                {
                    movingRight = false;
                    movingLeft = true;
                }
            }
            if (movingLeft == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, t1.position, step / 2);
                if (transform.position == t1.position)
                {
                    movingLeft = false;
                    movingRight = true;
                }
            }
        }else //if stop moving true
        {
            framesCounter++;
            if(framesCounter == framesToWait)
            {
                framesCounter = 0;
                stopMoving = false;
            }
        }
        //////////////////////////ANIMATIONS///////////////////////////////////////////////////////////

        if ((movingLeft == true) || (noDirection == true)) 
        {
            anim.SetBool("Left", true);
        }else if(movingRight == true)
        {
            anim.SetBool("Left", false);
        }
       
        
    }

    void ChrumRepeater() // being called every 2-6 seconds
    {
        int timeBeetwen;
        int whichSound;

        
        whichSound = Random.Range(1, 4); //randomizer for sound 1,2,3
        timeBeetwen = Random.Range(1, 7); //randomizer for time beetwen sounds

        switch (whichSound)
        {
            case 1:
                Invoke("PlayChrum1", timeBeetwen);
                break;
            case 2:
                Invoke("PlayChrum2", timeBeetwen);
                break;
            case 3:
                Invoke("PlayChrum3", timeBeetwen);
                break;
        }    
    }

    public void PlayChrum1()
    {
        aSource.PlayOneShot(chrum1, volume);       
    }
    public void PlayChrum2()
    {
        aSource.PlayOneShot(chrum2, volume);
    }
    public void PlayChrum3()
    {
        aSource.PlayOneShot(chrum3, volume);
    }


    private void OnDestroy()
    {
        Destroy(parentToDestroy);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") // jesli knur dotknie gracza
        {
            player.GetComponent<Player>().DamagePlayer(6);
           
            int randomize;
            randomize = Random.Range(1, 3);
            if(randomize ==1)
            {
                player.GetComponent<Player>().PlayKurwaKnurze();
            }else if(randomize == 2)
            {
                player.GetComponent<Player>().PlayOdpierdolsiekurwa();
            }
            stopMoving = true;            
        }
        if((collision.gameObject.tag == "kubek") || (collision.gameObject.tag == "cameraThrown")) //jesli knur dostanie kubkiem w ryja
        {
            deathAnimation.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
    
}