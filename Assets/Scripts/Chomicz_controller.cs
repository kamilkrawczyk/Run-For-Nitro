using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chomicz_controller : MonoBehaviour {

    public GameObject waypoint1;
    public GameObject waypoint2;
    private Transform waypoint1Transform;
    private Transform waypoint2Transform;
    private Vector3 startingPosition;
    public static float speed = 0.1f;
    private bool goToStartingPos;
    private bool goToWP1;
    private bool goToWP2;
    private bool chooseNextWP;
    private Animator anim;
    private float x1;

    public Image progressBar;
    public GameObject canvas;

    private bool isPlayerNearby;

    private GameObject player;

    public GameObject detector, dymek, odpychacz;
    private detector_chomincz detectorScript;

    public bool firstChomincz;
    [Space]
    public GameObject platform2lvl;

   
    
   
    // Use this for initialization
    void Start () {
        startingPosition = gameObject.transform.position;
        waypoint1Transform = waypoint1.GetComponent<Transform>();
        waypoint2Transform = waypoint2.GetComponent<Transform>();
        chooseNextWP = true;
        player = GameObject.FindGameObjectWithTag("Player");
        detectorScript = detector.GetComponent<detector_chomincz>();
        progressBar.fillAmount = 0;
        canvas.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
        isDying = false;
        x1 = transform.position.x;
    }
   
	// Update is called once per frame
	void Update () {
        isPlayerNearby = detectorScript.isPlayerNear;
        //////////////////////////////
        if(transform.position.x > x1)
        {
            anim.SetTrigger("right");
        }
        else if(transform.position.x < x1)
        {
            anim.SetTrigger("left");
        }
        else if(transform.position.x == x1)
        {
            anim.SetTrigger("idle");
        }
        x1 = transform.position.x;
//////////////////////////////////////////////
        if (chooseNextWP)
        {          
            if (NextWaypointRandomizer() == startingPosition)
            {
                goToStartingPos = true;
            }else if(NextWaypointRandomizer() == waypoint1Transform.position)
            {
                goToWP1 = true;
            }else if (NextWaypointRandomizer() == waypoint2Transform.position)
            {
                goToWP2 = true;
            }
        }
        if(!isDying)
        {
            if (!isPlayerNearby) //jak nie ma gracza w poblizu to se mozna chodzic
            {

                anim.SetBool("piszDonos", false);
                canvas.SetActive(false);
                progressBar.fillAmount = 0;
                NextWaypointRandomizer();
                if (goToStartingPos)
                {
                    chooseNextWP = false;
                    transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed);
                    if (transform.position == startingPosition)
                    {
                        goToStartingPos = false;
                        Invoke("WaitBeforeChoosingNextWP", Random.Range(2, 4));
                    }
                }
                else if (goToWP1)
                {
                    chooseNextWP = false;
                    transform.position = Vector3.MoveTowards(transform.position, waypoint1Transform.position, speed);
                    if (transform.position == waypoint1Transform.position)
                    {
                        goToWP1 = false;
                        Invoke("WaitBeforeChoosingNextWP", Random.Range(2, 4));
                    }
                }
                else if (goToWP2)
                {
                    chooseNextWP = false;
                    transform.position = Vector3.MoveTowards(transform.position, waypoint2Transform.position, speed);
                    if (transform.position == waypoint2Transform.position)
                    {
                        goToWP2 = false;
                        Invoke("WaitBeforeChoosingNextWP", Random.Range(2, 4));
                    }
                }
            }
            else //jesli jest w poblizu to piszemy donos
            {
                canvas.SetActive(true);
                progressBar.fillAmount += 0.009f;
                anim.SetBool("piszDonos", true);


                if (progressBar.fillAmount == 1) //chomik skonczyl pisac donos
                {

                    isPlayerNearby = true; //stop moving
                    RozpierdalanieMordy();
                    progressBar.fillAmount = 0;
                    canvas.SetActive(false);

                }
            }
        }    
    }
    bool isDying;
    void RozpierdalanieMordy()
    {
        isDying = true;

        anim.SetBool("rozpierMorde", true);
       
        //odpalamy animacje i znikamy

    }
    void Die()
    {
        player.GetComponent<Player>().DamagePlayer(5);
        
        Destroy(gameObject.transform.parent.gameObject);
    }
  
    void WaitBeforeChoosingNextWP() //use this with invoke
    {
        chooseNextWP = true;
    }
    
   
    Vector3 NextWaypointRandomizer() //losuje punkt do ktorego bedzie podazac chomik, oddaje Vector3 tego punktu
    {
        int randomNumber = Random.Range(1, 4);// od 1 do 3
        switch (randomNumber)
        {
            case 1:
                return startingPosition;             
            case 2:
                return waypoint1Transform.position;
            case 3:
                return waypoint2Transform.position;
        }
        return Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player")||(collision.tag == "Strus"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dymek.SetActive(true);
            canvas.SetActive(false);
            odpychacz.SetActive(false);
            Invoke("DestroyAll", .3f);
        }
    }
    void DestroyAll()
    {
        if(platform2lvl != null)
        {
            platform2lvl.GetComponent<Animator>().enabled = true;
        }      
        Destroy(gameObject.transform.parent.gameObject);
    }
}
