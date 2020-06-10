using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class nero_controller : MonoBehaviour
{
    public GameObject playerChecker, bar, barItself, topCollider, healthBar, leftBlocker, rightBlocker, startingPoint;
    private GameObject player;
    public bool isPlayerOnLeft, isPoolAround;
    public Vector3 poolLocation;
    private Vector3 playerLocation, jumpStartPos;
    private bool startMovingLeft, startMovingRight, stopper1;
    float timeToMove, speed = 3, startingYcoord;
    bool stopInvoking;
    
    public GameObject pool;
  
    private Animator anim;

    [Header("For dialogue")]
    public dialogue_global_controller dial_controller;
    public GameObject dialogueWin;





    private IEnumerator RutynaNera;
    // Start is called before the first frame update
    void Start()
    {
        isPoolAround = false;
        
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(GetPlayerLocation());
        RutynaNera = NeroRoutine();
        StartCoroutine(RutynaNera);
        
        
        startingYcoord = transform.position.y;
        stopper1 = false;
        anim = gameObject.GetComponent<Animator>();
        
       
    }
    void StartFight()
    {
        StartCoroutine("NeroRoutine");
    }

    // Update is called once per frame
    float count = 0.0f;
    bool stopper2, st3, st4, st5, st6, st7, st8;
    bool isFlicking;
    void Update()
    {
        float step = speed * Time.deltaTime;
        isPlayerOnLeft = playerChecker.GetComponent<isPlayerOnLeftOrRight_checker>().isPlayerOnLeft;
        isFlicking = topCollider.GetComponent<Nero_topCollider>().isFlicking;
        if(pool != null)
        {
            isPoolAround = pool.GetComponent<basen>().isPoolPresent;
            poolLocation = pool.transform.position;            
        }     
        if (isPoolAround)
        {
            if(!canCatchPlayer)
            {
                StopCoroutine(RutynaNera);
                if (Vector3.Distance(transform.position, poolLocation) > .6f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(poolLocation.x, transform.position.y, transform.position.z), step);
                    if(transform.position.x > poolLocation.x)//pool to the left
                    {
                        if(!st4)
                        {
                            anim.SetTrigger("PoolLeft");
                            st4 = true;
                        }                       
                    }
                    else //pool to the right
                    {
                        if(!st3)
                        {
                            anim.SetTrigger("PoolRight");
                            st3 = true;
                        }                    
                    }
                }
                else //dobiegl do basenu
                {                   
                    Destroy(pool);
                    if(!stopper2)
                    {
                        StartCoroutine(BitePool());
                        stopper2 = true;
                    }
                }
            }                  
        }
        if (startMovingLeft)
        {
            transform.Translate(new Vector3(-3f, 0, 0) * Time.deltaTime);
            if (!stopInvoking)
            {
                Invoke("StopMoving", timeToMove);
                stopInvoking = true;
            }
        }
        if (startMovingRight)
        {
            transform.Translate(new Vector3(3f, 0, 0) * Time.deltaTime);
            if (!stopInvoking)
            {
                Invoke("StopMoving", timeToMove);
                stopInvoking = true;
            }
        }
        if (startJumping)
        {
            if (count < 1) // jump
            {//animation
                if(!st5)
                {
                    SetJumpAnimation();
                    st5 = true;
                }             
                canCatchPlayer = true;
                count += .8f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(jumpStartPos, midPoint, count);
                Vector3 m2 = Vector3.Lerp(midPoint, locToJump, count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }
            else//jump ended
            {               
                canCatchPlayer = false;
                count = 0;
                st5 = false;
                if (bar.activeSelf == false) //jesli nie zlapal gracza
                {
                    ResetRoutine();
                }

                startJumping = false;              
            }

        }
        if(bar.activeSelf == true) // if health bar got activated
        {
            barItself.GetComponent<Image>().fillAmount += 0.003f;
            if(barItself.GetComponent<Image>().fillAmount==1) //gracz ugryziony
            {
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<Player>().enabled = true;
                player.GetComponent<Player>().BumpOnSpikes();
                player.GetComponent<Player>().LoseLife();
                barItself.GetComponent<Image>().fillAmount = .5f;

              
                anim.SetTrigger("BackToIdle");
                resetRoutine = true;
                bar.SetActive(false);
                
            }else if(barItself.GetComponent<Image>().fillAmount < 0.02f) // uwolniony
            {
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<Player>().enabled = true;
                player.GetComponent<PlayerInput>().enabled = true;
                anim.SetTrigger("BackToIdle");
                resetRoutine = true;
                barItself.GetComponent<Image>().fillAmount = .5f; //z powrotem na pol
                bar.SetActive(false);                             
            }
        }
        if(healthBar.GetComponent<Image>().fillAmount < 0.01f)//nero zdechl
        {
            if(!st8)
            {
                StopAllCoroutines();
                StartCoroutine(KoncoweUgryzienie());
                st8 = true;
            }        
        }
        if(routineEnded)//loop the routine
        {
            StartCoroutine(NeroRoutine());
            routineEnded = false;
        }             
        if (bar.activeSelf == true) //do skoku nera
        {
             if (Input.GetKeyDown("g"))
             {
                barItself.GetComponent<Image>().fillAmount -= 0.1f;              
                anim.SetTrigger("BiteWith");                                               
             }            
        }
      
        if (resetRoutine) 
        {
            StopCoroutine(RutynaNera);
           
            if(!st6)
            {
                SetResetAnimation();
                st6 = true;
            }

            if(transform.position != startingPoint.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPoint.transform.position, step*1.5f);
            }
            else if(transform.position == startingPoint.transform.position) // jesli przy startowym punkcie znow zacznij rutyne
            {
                st1 = false; //reset it
                anim.SetTrigger("Idle");
                StartCoroutine(RutynaNera);
                st6 = false;
                resetRoutine = false;
            }
        }
        
    }



    private bool routineEnded;   
    private IEnumerator NeroRoutine()
    {      
        routineEnded = false;

        
        yield return new WaitForSeconds(2);
        MoveLeft(1);
        yield return new WaitForSeconds(2);
        MoveRight(1);
        yield return new WaitForSeconds(2);
        JumpAtPlayer();
        yield return new WaitForSeconds(3);










        routineEnded = true;
            yield break;
              
    }
    bool resetRoutine;
    void ResetRoutine() // go to starting point
    {
        resetRoutine = true;      
    }
    bool st1;
    void RandomizeAction()
    {
        int rand = UnityEngine.Random.Range(1, 4);
        switch(rand)
        {
            case 1:
                BarkAtPlayer();
                break;
            case 2:
                JumpAtPlayer();
                break;
            case 3:
                MoveRight(1);
                break;
            case 4:
                MoveLeft(1);
                break;
        }
    }
    void StopMoving()
    {
        anim.SetTrigger("Idle");
        startMovingLeft = false;
        startMovingRight = false;
    }
    void MoveLeft(float amount)
    {
        anim.SetTrigger("MoveLeft");
        timeToMove = amount;
        startMovingLeft = true;
        stopInvoking = false;
    }
    void MoveRight(float amount)
    {
        anim.SetTrigger("MoveRight");
        timeToMove = amount;
        startMovingRight = true;
        stopInvoking = false;
    }
    void SetJumpAnimation()
    {       
        if(locToJump.x > transform.position.x)
        {
            anim.SetTrigger("JumpRight");
        }
        else
        {
            anim.SetTrigger("JumpLeft");
        }
    }
    void SetResetAnimation()
    {
        if(transform.position.x < startingPoint.transform.position.x)
        {
            anim.Play("NeroWalkRIGHT");
        }
        else
        {
            anim.Play("NeroWalkLEFT");
        }
    }
  
    void BarkAtPlayer()//szczeka w kierunku gracza
    {
        if(isPlayerOnLeft)//w lewo
        {
            StartCoroutine(Bark("left"));
        }
        else//w prawo
        {
            StartCoroutine(Bark("right"));
        }
    }
    [Space]
    public GameObject left_bark_1, left_bark_2, left_bark_3, right_bark_1, right_bark_2, right_bark_3;
    IEnumerator Bark(string orientation)
    {
        if(orientation == "left")
        {
            anim.SetTrigger("BarkLEFT");
            left_bark_1.SetActive(true);
            yield return new WaitForSeconds(.6f);
            left_bark_1.SetActive(false);
            left_bark_2.SetActive(true);
            yield return new WaitForSeconds(.6f);
            left_bark_2.SetActive(false);
            left_bark_3.SetActive(true);
            yield return new WaitForSeconds(.6f);
        }
        else if(orientation == "right")
        {
            anim.SetTrigger("BarkRIGHT");
            right_bark_1.SetActive(true);
            yield return new WaitForSeconds(.6f);
            right_bark_2.SetActive(true);
            yield return new WaitForSeconds(.6f);
            right_bark_3.SetActive(true);
            yield return new WaitForSeconds(.6f);
        }
        left_bark_1.SetActive(false);
        left_bark_2.SetActive(false);
        left_bark_3.SetActive(false);
        right_bark_1.SetActive(false);
        right_bark_2.SetActive(false);
        right_bark_3.SetActive(false);
        anim.SetTrigger("BackToIdle");
        yield break;
    }
    private Vector3 locToJump;
    private Vector3 midPoint;
    private bool startJumping;
    void JumpAtPlayer()
    {
        locToJump = new Vector3(playerLocation.x, startingYcoord, playerLocation.z);        
        midPoint = transform.position + (locToJump - transform.position) / 2 + Vector3.up * 4;
        jumpStartPos = transform.position;
        startJumping = true;       
    }
    private bool canCatchPlayer;
    private bool isVulnerable;
    IEnumerator BitePool()
    {
        isPoolAround = false;
        topCollider.GetComponent<BoxCollider2D>().enabled = true; //mozna na niego skoczyc
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetTrigger("Bite");
        yield return new WaitForSeconds(5); //czas gryzienia
        if (topCollider.GetComponent<Nero_topCollider>().isFlicking)
        {
            yield return new WaitForSeconds(2.5f); //add a couple of seconds of is flicking
        }       
        anim.SetTrigger("BackToIdle");
        yield return new WaitForSeconds(2);       
        ResetRoutine();
        topCollider.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;         
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (canCatchPlayer) //skoczyl na gracza
            {
                Debug.Log("skoczyl na gracza");
                StopCoroutine(RutynaNera);             
                anim.SetTrigger("BiteWithout");
                if(!player.GetComponent<Player>().IsGrounded()) //zlapal gracza w locie
                {
                    player.GetComponent<Player>().velocity.x = 0;
                    player.GetComponent<Player>().directionalInput = Vector2.zero;
                    player.GetComponent<PlayerInput>().enabled = false;                                       
                }
                bar.SetActive(true);
                player.GetComponent<Player>().enabled = false;
                player.GetComponent<SpriteRenderer>().enabled = false;

            }
            else //gracz dotknal groznego psa bozego
            {
                player.GetComponent<Player>().LoseLife();
                player.GetComponent<Player>().PlayPsiejebany();
                player.GetComponent<Player>().BumpUpCustom(4);
            }
        }
        if (collision.CompareTag("cameraThrown") || collision.CompareTag("kubek"))
        {
            if(!isFlicking)//mozna go walnac tylko jak nie miga
            {
                if (collision.CompareTag("cameraThrown"))
                {
                    collision.gameObject.GetComponent<camera_to_throw>().EnemyHit();
                }
                if (collision.CompareTag("kubek"))
                {
                    try
                    {
                        collision.gameObject.GetComponent<Kubek_throw_left>().EnemyHit();
                        collision.gameObject.GetComponent<Kubek_throw_right>().EnemyHit();
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                    }
                    
                }
                healthBar.GetComponent<Image>().fillAmount -= 0.09f;
                topCollider.GetComponent<Nero_topCollider>().StartCoroutine(topCollider.GetComponent<Nero_topCollider>().Flick());
            }        
        }
    }
    IEnumerator KoncoweUgryzienie()
    {
        StopCoroutine(RutynaNera);
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        yield return new WaitForSeconds(2);

        playerLocation = player.transform.position;//dokladna lokacja
        JumpAtPlayer();
        topCollider.SetActive(false);
        yield return new WaitUntil(() => bar.activeSelf == true);
        bar.SetActive(false);
        anim.SetTrigger("BiteEnd");

        yield return new WaitForSeconds(1);

        Cursor.visible = true;
        dialogueWin.SetActive(true);
        dial_controller.AtTheDialogueStart();
        dial_controller.NameChange("Major");
        dial_controller.PortraitChange(dial_controller.portretMaj);
        dial_controller.StartCoroutine(dial_controller.typewriter.GetComponent<typewriter_effect>().ShowText(" "));

        yield return new WaitForSeconds(.5f);

        dial_controller.NaKoncuNera();
        yield break;
    }





    
   







}           
        
    


