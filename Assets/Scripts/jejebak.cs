using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jejebak : MonoBehaviour
{
    public Image healthBar;
    public GameObject player, playerChecker, prawkoToSpawn, groundChecker, p1, p2, p3, p4, p5, piwoToSpawn, gameCamera, dialogueController, typeWriter;
    public GameObject itemSpawner1, itemSpawner2;
    private bool startMovingLeft, startMovingRight, startJumping, invincible;
    public bool isPlayerOnLeft;//if tru left, if false right
    float timeToMove;
    bool stopInvoking;
    public LayerMask groundLayer;
    private Animator anim;

    public GameObject canvasMario;

    private bool isInTheAir, routineEnded, canDie, startStoppingRoutine;
    private float startingYcoord;

    Vector3 dir = Vector3.up;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1;
        anim = GetComponent<Animator>();
        startMovingLeft = false; startMovingRight = false;      
        startingYcoord = gameObject.transform.position.y;
        coroutine = JejebakRoutine();     
        canDie = true;
        invincible = true;
        //StartCoroutine(coroutine);
    }

    public void StartFight()
    {
        StartCoroutine(coroutine);
        canvasMario.SetActive(true);
        itemSpawner1.SetActive(true); itemSpawner2.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
        isPlayerOnLeft = playerChecker.GetComponent<isPlayerOnLeftOrRight_checker>().isPlayerOnLeft;
       // Debug.Log(isPlayerOnLeft);
        if(startMovingLeft)
        {
           
            transform.Translate(new Vector3(-3f, 0, 0) * Time.deltaTime);
            if(!stopInvoking)
            {
                Invoke("StopMoving", timeToMove);
                stopInvoking = true;
            }        
        }

        if(startMovingRight)
        {
            
            transform.Translate(new Vector3(3f, 0, 0) * Time.deltaTime);
            if (!stopInvoking)
            {
                Invoke("StopMoving", timeToMove);
                stopInvoking = true;
            }
        }

        if(startJumping) //JUMP
        {               
            gameObject.transform.Translate(dir * 40 *  Time.deltaTime);
            dir -= new Vector3(0, .008f, 0);
            if (dir == Vector3.zero)
            {
                dir = new Vector3(0, -0.01f, 0);
            }
            if(!IsTouchingGround())
            {
                isInTheAir = true;
            }
            if(isInTheAir)
            {
                if(IsTouchingGround())
                {
                    //stop falling
                    dir = Vector3.zero;
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x,2,gameObject.transform.position.z);
                    startJumping = false;
                }
            }                 
        }

        if(routineEnded) //for routine loop
        {
            StartCoroutine("JejebakRoutine");
            routineEnded = false;
        }

        if(canDie)
        {
            if (healthBar.fillAmount == 0)
            {
                Die();
                canDie = false;
            }
        }
     
        if(startStoppingRoutine)
        {
            StopCoroutine(coroutine);
        }
        
        if (gameCamera.GetComponent<CameraUtilities>().movementDone)
        {
            StartCutscene();
            gameCamera.GetComponent<CameraUtilities>().movementDone = false;
        }
      
        
    }
    public void Jump()
    {
        startJumping = true;
        dir = Vector3.up * .2f;
    }

    IEnumerator JejebakRoutine()
    {
        invincible = false;
        MoveLeft(1);
        yield return new WaitForSeconds(3);
        ThrowTest("left");
        yield return new WaitForSeconds(2);
        MoveRight(.5f);
        yield return new WaitForSeconds(2);
        MoveRight(.5f);
        yield return new WaitForSeconds(2);
        ThrowBeerAround();
        yield return new WaitForSeconds(3);
        MoveRight(1);
        yield return new WaitForSeconds(3);
        ThrowTest("left");
        yield return new WaitForSeconds(2);
        MoveRight(.5f);
        yield return new WaitForSeconds(3);
        ThrowTest("player");
        yield return new WaitForSeconds(1);
        ThrowTest("player");
        yield return new WaitForSeconds(1);
        MoveLeft(1);
        yield return new WaitForSeconds(1);
        ThrowBeerAround();
        yield return new WaitForSeconds(2);
        ThrowBeerAround();
        yield return new WaitForSeconds(1);
        MoveLeft(1);
        yield return new WaitForSeconds(2);
        MoveLeft(1);
        yield return new WaitForSeconds(2);
        ThrowTest("player");
        yield return new WaitForSeconds(2);
        MoveRight(1);
        yield return new WaitForSeconds(2);
        MoveLeft(1);
        yield return new WaitForSeconds(2);
        Jump();
        yield return new WaitForSeconds(3);
        ThrowBeerAround();
        yield return new WaitForSeconds(2);
        ThrowTest("player");
        yield return new WaitForSeconds(1);
        ThrowTest("player");
        yield return new WaitForSeconds(1);
        MoveRight(1.5f);
        yield return new WaitForSeconds(2);
        ThrowBeerAround();
        yield return new WaitForSeconds(1);
    

        routineEnded = true;
        yield break;
    }
    void StopMoving()
    {
        startMovingLeft = false;
        startMovingRight = false;
        anim.SetTrigger("StopMoving");
        anim.SetTrigger("StopThrowing");
    }
  
    void OnCollisionEnter2D(Collision2D collision)
    {        
            if (collision.gameObject.tag == "Player")
            {
                player.GetComponent<Player>().DamagePlayer(6);
                player.GetComponent<Player>().PlayOdpierdolsiekurwa();              
            }   
            if(collision.gameObject.tag == "cameraThrown")
            {
                if(!invincible)
                {
                    collision.gameObject.GetComponent<camera_to_throw>().EnemyHit();
                    LooseLife();
                    StartCoroutine(Flick());
                }
                else//if invincible
                {
                    collision.gameObject.GetComponent<camera_to_throw>().Puff();
                }
              
            }
            else if(collision.gameObject.tag =="kubek")
            {
            if (!invincible)
            {
                try
                {
                    collision.gameObject.GetComponent<Kubek_throw_left>().EnemyHit();
                    collision.gameObject.GetComponent<Kubek_throw_right>().EnemyHit();
                }
                catch
                {
                    //spoko
                }
                LooseLife();
                StartCoroutine(Flick());
            }
            else//if invincible
            {
                try
                {
                    collision.gameObject.GetComponent<Kubek_throw_left>().EnemyHit();
                    collision.gameObject.GetComponent<Kubek_throw_right>().EnemyHit();
                }
                catch
                {
                    //spoko
                }
            }
        }
    }
    public void LooseLife()
    {
        if(!invincible)
        {
            healthBar.fillAmount -= 0.15f;
        } 
    }
    void Die()
    {
        Debug.Log("die");
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        startStoppingRoutine = true;
        gameCamera.GetComponent<CameraFollow>().enabled = false;
        Vector2 myPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        gameCamera.GetComponent<CameraUtilities>().MoveCameraToPoint(myPosition, 5);       
    }
    void StartCutscene()  //coroutine will be stopping whole
    {
        Debug.Log("startcutscene");
        dialogueController.GetComponent<dialogue_global_controller>().AtTheDialogueStart();
        dialogueController.GetComponent<dialogue_global_controller>().NameChange("Mario");
        dialogueController.GetComponent<dialogue_global_controller>().PortraitChange(dialogueController.GetComponent<dialogue_global_controller>().portretMario);
        Invoke("FirstType", .5f);
        dialogueController.GetComponent<dialogue_global_controller>().whichText = 41;
        startStoppingRoutine = false;
    }
    void FirstType()
    {
        StartCoroutine(typeWriter.GetComponent<typewriter_effect>().ShowText("Aaaaa... Pokonales mnie Majorze.... Ale wiedz, ze jestem tylko podrzednym pionkiem. Z moim Mistrzem nie pojdzie Ci tak latwo, lalusiu!!"));
    }
   
    void MoveLeft(float amount)
    {
        anim.SetTrigger("StartMovingLeft");
        timeToMove = amount;
        startMovingLeft = true;
        stopInvoking = false;
    }
    void MoveRight(float amount)
    {
        anim.SetTrigger("StartMovingRight");
        timeToMove = amount;
        startMovingRight = true;
        stopInvoking = false;
    }
    void ThrowTest(string direction) //type in 'left' or 'right' or 'player'
    {
        if(direction == "left")
        {
            anim.SetTrigger("ThrowLeft");
            GameObject test = Instantiate(prawkoToSpawn,p1.transform.position, p1.transform.rotation);
            test.GetComponent<prawko>().orientation = prawko.Orientation.Left;
            
        }else if(direction == "right")
        {
            anim.SetTrigger("ThrowRight");
            GameObject test = Instantiate(prawkoToSpawn, p5.transform.position, p5.transform.rotation);
            test.GetComponent<prawko>().orientation = prawko.Orientation.Right;
        }else if(direction == "player")
        {
            if(isPlayerOnLeft)
            {
                ThrowTest("left");
            }else if(!isPlayerOnLeft)
            {
                ThrowTest("right");
            }
        }
    }
    void ThrowBeerAround()
    {
        anim.SetTrigger("Focus");
        GameObject piwo = Instantiate(piwoToSpawn, p1.transform.position, p1.transform.rotation);
        piwo.GetComponent<piwo_bezalkoholowe>().SetFlySettings(new Vector3(-1,0,0),3.5f);

        GameObject piwo2 = Instantiate(piwoToSpawn, p3.transform.position, p3.transform.rotation);
        piwo2.GetComponent<piwo_bezalkoholowe>().SetFlySettings(new Vector3(0, 1, 0), 3.5f);

        GameObject piwo3 = Instantiate(piwoToSpawn, p5.transform.position, p5.transform.rotation);
        piwo3.GetComponent<piwo_bezalkoholowe>().SetFlySettings(new Vector3(1, 0, 0), 3.5f);

        Invoke("ThrowBeerStepTwo", .5f);
    }
    void ThrowBeerStepTwo()
    {
        GameObject piwo4 = Instantiate(piwoToSpawn, p2.transform.position, p2.transform.rotation);
        piwo4.GetComponent<piwo_bezalkoholowe>().SetFlySettings(new Vector3(-.5f, 1, 0), 3.5f);

        GameObject piwo5 = Instantiate(piwoToSpawn, p4.transform.position, p4.transform.rotation);
        piwo5.GetComponent<piwo_bezalkoholowe>().SetFlySettings(new Vector3(.5f, 1, 0), 3.5f);
        anim.SetTrigger("StopThrowing");
    }

    bool IsTouchingGround()
    {

        Vector3 direction = Vector3.down;
        float distance = .1f;
        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker.transform.position, direction, distance, groundLayer);       
        if (hit1.collider != null)
        {
            return true;
        }

        return false;
    }
    
    IEnumerator Flick()
    {
        invincible = true;
        for (int i = 0; i < 7; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        invincible = false;
        yield break;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

   
}
