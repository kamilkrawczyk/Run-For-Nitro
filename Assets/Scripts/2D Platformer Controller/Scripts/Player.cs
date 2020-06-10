using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public bool canDoubleJump;
    private bool isDoubleJumping = false;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
    public Vector3 velocity;
    private float velocityXSmoothing;

    private Controller2D controller;

    public Vector2 directionalInput;
    private bool wallSliding;
    private int wallDirX;

    public Animator anim;

    
    public LayerMask groundLayer;
  
   
    public LayerMask enemyLayer;

    private bool lockKey1, lockKey2;

    public GameObject liczba_zyc_UI, number_of_cameras_UI;
    public TextMeshProUGUI m_liczba_zyc; //text
    public int liczba_zyc; // na start
    public TextMeshProUGUI strus_countdown_UI;
    private int strusCountdown = 30;

    //Kamery i kubki  
    public GameObject liczba_kamer_obiekt;
    public GameObject liczba_kubkow_obiekt;

    private int liczba_kubkow;
    private int liczba_kamer;

    public AudioClip kamera_tekst_1, kamera_tekst_2, kamera_tekst_3;
    public AudioClip wyjebaccitymkubkiem;



    private bool hasBumped;//bumper starter
    private int bumps;
    public float bumpsMax = 10; //max frames that player will be kicked into air by colliding with enemy
   
  
   

    public GameObject kubekToThrowLeft;
    public GameObject kubekToThrowRight;
    public GameObject kameraToThrow;
    public GameObject basenToThrow;
    public GameObject NeroHealthBar;

    private SpriteRenderer c_spriteRenderer;
    public GameObject bumpLeftSprite;
    public GameObject bumpRightSprite;
    public GameObject bumpUpSprite;
    

    bool IsFirstTime; //bool for calculating dir vector

    public AudioClip ochollera;
    public AudioClip roze;
    public AudioClip muszemieclepszawiadomosc;
    public AudioClip fajnaniespodzianka;
    AudioSource aSource;
    public float audioVolume = 1;
    public AudioClip kurwaknurze;
    public AudioClip jakkurwazapierdolilemtokurwazwersalkispadali, odpierdolsiekurwa, dobrzezekupilem, niemamprowojazdy, bozaraztorozwaletakamere, topiwonienadajesiedopicia;
    public AudioClip luuuotakrobi, psiejebany, janielalus, chcemniedochoroszczywyslac, wmajtkinasralemkurwa, musialemtwarozekzjesc;
    public AudioClip dzwiekObrazen, dzwiekZebraniaBroni;
    public GameObject uiCanvas;
    public GameObject deathCanvas;

    [Header("ogolem cale te klipy")]
    public AudioClip o1;
    public AudioClip o2;
    public AudioClip o3;
    public AudioClip o4;
    public AudioClip o5;
    public AudioClip o6;
    public AudioClip o7;
    public AudioClip o8;
    public AudioClip o9;
    public AudioClip o10;
    public AudioClip o11;
    [Space]

    public GameObject basenUI;

    private Vector3 UIcupScaleStart, UIcameraScaleStart;

    private bool alreadyChecked = true; //helping bool for kicking off the platform ogółem
    bool canShoot; // czy mozna rzucac
    [Header("UI Elements")]
    public GameObject UIcamera;
    public GameObject UIcup;
    public GameObject liczba_kubkow_UI;
    
    [Header("Children")]
    public GameObject groundChecker1;
    public GameObject groundChecker2;
    public GameObject enemyCheckLeft1;
    public GameObject enemyCheckLeft2;
    public GameObject enemyCheckRight1;
    public GameObject enemyCheckRight2;
    [HideInInspector]
    public bool startBumpingRight;
    public bool startBumpingLeft;
    public bool startBumpingUp; //spikes bump

    enum facingDirection {left, right}
    facingDirection fDir;
    enum weaponChosen {kubek, kamera}
    weaponChosen _weaponChosen;
    enum playingMode {normal, strus}
    playingMode _playingMode;

    private GameObject checkpointSystem;

    public GameObject poolSpawner;//ten z 3levela

   






    ///////////////////////////////////////////////////////////////////////////////////////////////////

    public bool IsGrounded() //checks if player is touching the ground
    {
        
        Vector3 direction = Vector3.down;
        float distance = 1.0f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker1.transform.position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(groundChecker2.transform.position, direction, distance, groundLayer);
        if ((hit1.collider != null) || (hit2.collider != null))
        {
            return true;
        }

        return false;
    }
    bool IsEnemyOnLeft()
    {
        Vector3 direction = Vector3.left;
        float distance = 0.5f;

        RaycastHit2D hit1 = Physics2D.Raycast(enemyCheckLeft1.transform.position, direction, distance, enemyLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(enemyCheckLeft2.transform.position, direction, distance, enemyLayer);
        if ((hit1.collider != null) || (hit2.collider != null))
        {                         
                return true;                                     
        }
        return false;
    } //true if enemy is near left side of the player
    bool IsEnemyOnRight()
    {
        Vector3 direction = Vector3.right;
        float distance = 0.5f;

        RaycastHit2D hit1 = Physics2D.Raycast(enemyCheckRight1.transform.position, direction, distance, enemyLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(enemyCheckRight2.transform.position, direction, distance, enemyLayer);
        if ((hit1.collider != null) || (hit2.collider != null))
        {
            return true;
        }
        return false;
    } //true if enemy is near right side of the player
    bool IsTouchingPlatform()//fix for platform bug
    {
        Vector3 direction = Vector3.down;
        float distance = 0.001f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker1.transform.position, direction, distance, groundLayer);
       
        if ((hit1.collider != null))
        {
            return true;
        }
        return false;
    }
  
   
   /////////////////////////////////////////////////ITEMS//////////////////////////////////////  
    public void LoseLife()
    {
        liczba_zyc--;
        m_liczba_zyc.text = "" + liczba_zyc;
        if (liczba_zyc == 0) Death();        
               
    } //-1 life
    void Death() //when player die
    {
        Time.timeScale = 0;
        uiCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        Cursor.visible = true;

    }
    public void AddLife() //when player pick up nitro
    {
        liczba_zyc++;
        m_liczba_zyc.text = "" + liczba_zyc;
        int soundRandomizer;
        soundRandomizer = Random.Range(1, 4);
        switch(soundRandomizer)
        {
            case 1:
                aSource.PlayOneShot(roze, audioVolume);
                break;
            case 2:
                aSource.PlayOneShot(muszemieclepszawiadomosc, audioVolume);
                break;
            case 3:
                aSource.PlayOneShot(fajnaniespodzianka, audioVolume);
                break;
        }
        

    }

    public void AddCameras(int amount)
    {
        ZagrajDzwiekZbieraniaBroni();

        liczba_kamer += amount;
        liczba_kamer_obiekt.GetComponent<TextMeshProUGUI>().text = "" + liczba_kamer;

        int randomize = Random.Range(1, 3);
        switch(randomize)
        {
            case 1:
                aSource.PlayOneShot(kamera_tekst_1, 1);
                break;
            case 2:
                aSource.PlayOneShot(kamera_tekst_2, 1);
                break;
            case 3:
                aSource.PlayOneShot(kamera_tekst_3, 1);
                break;
        }
    
    }
    public void AddCups(int amount)
    {
        ZagrajDzwiekZbieraniaBroni();

        liczba_kubkow += amount;
        liczba_kubkow_obiekt.GetComponent<TextMeshProUGUI>().text = "" + liczba_kubkow;

        aSource.PlayOneShot(wyjebaccitymkubkiem, 1);
    }
    void ThrowCamera()
    {
        liczba_kamer--;
        liczba_kamer_obiekt.GetComponent<TextMeshProUGUI>().text = "" + liczba_kamer;
    }
    void ThrowCup()
    {
        liczba_kubkow--;
        liczba_kubkow_obiekt.GetComponent<TextMeshProUGUI>().text = "" + liczba_kubkow;

    }
    //todo tekty nie mam kamery i nie mam kubka



    void ThrowCupLeft() 
    {
        if(canShoot)
        {
            if (liczba_kubkow > 0)
            {
                GameObject kubek = (GameObject)Instantiate(kubekToThrowLeft, enemyCheckLeft1.transform.position, enemyCheckRight1.transform.rotation);
                ThrowCup();
                anim.SetTrigger("throwLeft");
                canShoot = false;
            }
        }            
    }
    void ThrowCupRight() 
    {
        if (canShoot)
        {
            if (liczba_kubkow > 0)
            {
                GameObject kubek = Instantiate(kubekToThrowRight, enemyCheckRight1.transform.position, enemyCheckRight1.transform.rotation);
                ThrowCup();
                anim.SetTrigger("throwRight");
                canShoot = false;
            }
        }            
    }
    void ThrowCameraLeft() 
    {
        if (canShoot)
        {
            if (liczba_kamer  >0)
            {
                GameObject cameraThrown = Instantiate(kameraToThrow, enemyCheckLeft1.transform.position, enemyCheckLeft1.transform.rotation);
                cameraThrown.GetComponent<camera_to_throw>().orientation = camera_to_throw.Orientation.Left;
                ThrowCamera();
                anim.SetTrigger("throwLeft");
                canShoot = false;
            }
        }
    }
    void ThrowCameraRight() 
    {
        if(canShoot)
        {
            if (liczba_kamer > 0)
            {
                GameObject cameraThrown = Instantiate(kameraToThrow, enemyCheckRight1.transform.position, enemyCheckRight1.transform.rotation);
                cameraThrown.GetComponent<camera_to_throw>().orientation = camera_to_throw.Orientation.Right;
                ThrowCamera();
                anim.SetTrigger("throwRight");
                canShoot = false;
            }
        }
    }
     
    public void ThrowPool()
    {
      GameObject pool = Instantiate(basenToThrow, enemyCheckRight1.transform.position, enemyCheckRight1.transform.rotation) as GameObject;  
        
    }

    
    private void Start()
    {
        controller = GetComponent<Controller2D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        anim = GetComponent<Animator>();
        m_liczba_zyc = liczba_zyc_UI.GetComponent<TextMeshProUGUI>();               
        liczba_zyc = 3;
        m_liczba_zyc.text = ""+liczba_zyc;
        c_spriteRenderer = GetComponent <SpriteRenderer>();
        IsFirstTime = true;
        aSource = GetComponent<AudioSource>();
        uiCanvas.SetActive(true);
        Time.timeScale = 1;
        canShoot = true;
        stopper1 = false;
        fDir = facingDirection.right;//default value
        UIcameraScaleStart = UIcamera.transform.localScale;
        UIcupScaleStart = UIcup.transform.localScale;
        SetStartingWeapon("camera");
        _playingMode = playingMode.normal;

        if(SceneManager.GetActiveScene().name == "Level4") //jesli jestesmy na ksinzycu
        {
            gravity /= 2;
        }

        checkpointSystem = GameObject.FindGameObjectWithTag("CheckPSystem");
        //checkpoint stuff

        liczba_kamer = 0;
        liczba_kubkow = 0;
        

        Cursor.visible = false;
       
    }
    
    void SetStartingWeapon(string weapon)//camera or cup
    {
        if(weapon == "cup")
        {
            UIcup.transform.localScale *= 1.2f;
            _weaponChosen = weaponChosen.kubek;
            lockKey1 = true;
        }else if(weapon == "camera")
        {
            UIcamera.transform.localScale *= 1.2f;
            _weaponChosen = weaponChosen.kamera;
            lockKey2 = true;
        }

    }
   
    IEnumerator CanShootAgain()
    {
        yield return new WaitForSeconds(.5f);
        canShoot = true; stopper1 = false;
        yield break;
    }
    IEnumerator LooseStrusTime()
    {
        while(strusCountdown > 0)
        {
            strusCountdown--;
            yield return new WaitForSeconds(1);
        }
        if(strusCountdown == 0)
        {
            _playingMode = playingMode.normal;
        }
        yield break;
    }

    bool stopper1;
    bool stopper2;
    private void Update()
    {
        //strus countdown   
        if(strus_countdown_UI != null) strus_countdown_UI.text = (strusCountdown).ToString();




        if (!canShoot)//wait to change canshoot
        {
            if(!stopper1)
            {
                StartCoroutine(CanShootAgain());
                stopper1 = true;
            }           
        }       
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));   
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fDir = facingDirection.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fDir = facingDirection.right;
        }
        if (Input.GetButtonDown("Fire"))
        {
            if(_playingMode == playingMode.normal)
            {
                if (_weaponChosen == weaponChosen.kamera)
                {
                    if (fDir == facingDirection.left)
                    {
                        ThrowCameraLeft();
                    }
                    else if (fDir == facingDirection.right)
                    {
                        ThrowCameraRight();
                    }
                }
                else if ((_weaponChosen == weaponChosen.kubek))
                {
                    if (fDir == facingDirection.left)
                    {
                        ThrowCupLeft();
                    }
                    else if (fDir == facingDirection.right)
                    {
                        ThrowCupRight();
                    }
                }
            }
           
        }
        if(basenUI != null) //basen dla nera
        {
            if(basenUI.GetComponent<RawImage>().enabled == true)
            {
                if (Input.GetKeyDown("r"))
                {
                    ThrowPool();
                    poolSpawner.SetActive(true);
                    basenUI.GetComponent<RawImage>().enabled = false;
                }
            }
        }
        //Kierowanie spawnerem basenow
        

        ///////////------------------------------------------------



        CalculateVelocity();
        HandleWallSliding();
            
        controller.Move(velocity * Time.deltaTime, directionalInput);
           
        if (controller.collisions.above || controller.collisions.below) //nie wiem jak to dziala ale dziala
        {
            velocity.y = 0f;          
        }

        if (alreadyChecked == false) //for removing kicking off platform bug
        {
            if (IsTouchingPlatform() == true)
            {
                velocity = Vector3.zero;
                alreadyChecked = true;
            }
        }else if(IsTouchingPlatform() == false)
        {
            alreadyChecked = false;
        }
        //Changing UI       
        //Changing weapon by 1 and 2
        if(Input.GetKeyDown("1"))
        {
            if(!lockKey1)
            {
                _weaponChosen = weaponChosen.kubek;
                UIcup.transform.localScale *= 1.2f;
                UIcamera.transform.localScale = UIcameraScaleStart;
                lockKey1 = true; lockKey2 = false;
            }       
        }else if(Input.GetKeyDown("2"))
        {
            if(!lockKey2)
            {
                _weaponChosen = weaponChosen.kamera;
                UIcamera.transform.localScale *= 1.2f;
                UIcup.transform.localScale = UIcupScaleStart;
                lockKey1 = false; lockKey2 = true;
            }      
        }
        /// ANIMATIONS
        anim.SetBool("isGrounded", IsGrounded());
        if (_playingMode == playingMode.strus)
        {
            gameObject.tag = "Strus";
            anim.SetBool("isInStrusMode", true);
            
        }
        if (_playingMode == playingMode.normal)
        {
            gameObject.tag = "Player";
            anim.SetBool("isInStrusMode", false);
        }
        ////-----------------------------------------------
        if (liczba_zyc > 5) liczba_zyc = 5;
        else if (liczba_zyc < 0) liczba_zyc = 0;
        // sterowanie zyciami:
        if ((liczba_zyc >= 0) && (liczba_zyc <= 4)) _playingMode = playingMode.normal;
        if (liczba_zyc == 5) _playingMode = playingMode.strus;
        if(_playingMode == playingMode.strus) //wchodzimy w tryb strusia na 30 sekund
        {         
            if(!stopper2)
            {
                StartCoroutine(SwitchToStusMode());
                stopper2 = true;
            }
        }
        ////-----Ogołem całe te play
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            PowiedzOgolem();
        }

    
    }
    [HideInInspector]
    public int secondsToSwitch = 30;
    IEnumerator SwitchToStusMode() //zostajemy strusiem na 30 sekund
    {
        moveSpeed *= 1.5f;
        anim.SetTrigger("strusMode");
        StartCoroutine(LooseStrusTime());

        yield return new WaitForSeconds(secondsToSwitch);
        moveSpeed /= 1.5f;

        yield break;
    }

  

    public void Bump()
    {
        if(IsEnemyOnLeft() == true)
        {
            BumpRight();

        }else if(IsEnemyOnRight() == true)
        {
            BumpLeft();
        }     
    }
    public void BumpOnSpikes()
    {
        velocity.y = maxJumpHeight * 8 ;
        c_spriteRenderer.enabled = false;
        bumpUpSprite.SetActive(true);
        Invoke("StopBump", 0.5f);       
    }
    public void BumpUpCustom(float x)//type in the value to control the jump height
    {
        velocity.y = maxJumpHeight * x;
        c_spriteRenderer.enabled = false;
        bumpUpSprite.SetActive(true);
        Invoke("StopBump", 0.5f);
    }
    public void StopBump()
    {
        c_spriteRenderer.enabled = true;
        bumpRightSprite.SetActive(false);
        bumpLeftSprite.SetActive(false);
        bumpUpSprite.SetActive(false);
    }
    private float bumpMultiplier = 750;
    public void BumpLeft()
    {
        velocity = new Vector3(-1, 0.6f, 0) * bumpMultiplier * Time.deltaTime;
        c_spriteRenderer.enabled = false;
        bumpLeftSprite.SetActive(true);
        Invoke("StopBump", 0.5f);
    }
    public void BumpRight()
    {
        velocity = new Vector3(1, 0.6f, 0) * bumpMultiplier * Time.deltaTime;
        c_spriteRenderer.enabled = false;
        bumpRightSprite.SetActive(true);
        Invoke("StopBump", 0.5f);
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            isDoubleJumping = false;
        }
        if (controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = false;
        }
        if (canDoubleJump && !controller.collisions.below && !isDoubleJumping && !wallSliding)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = true;
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    private void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0f)
            {
                velocityXSmoothing = 0f;
                velocity.x = 0f;
                if (directionalInput.x != wallDirX && directionalInput.x != 0f)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;
    }
    
    public void ShotEnded()
    {
        anim.SetTrigger("shotEnded");        
    }

    void PowiedzOgolem()
    {
        int randomize = Random.Range(1, 12);
        switch(randomize)
        {
            case 1:
                aSource.PlayOneShot(o1, 1);
                break;
            case 2:
                aSource.PlayOneShot(o2, 1);
                break;
            case 3:
                aSource.PlayOneShot(o3, 1);
                break;
            case 4:
                aSource.PlayOneShot(o4, 1);
                break;
            case 5:
                aSource.PlayOneShot(o5, 1);
                break;
            case 6:
                aSource.PlayOneShot(o6, 1);
                break;
            case 7:
                aSource.PlayOneShot(o7, 1);
                break;
            case 8:
                aSource.PlayOneShot(o8, 1);
                break;
            case 9:
                aSource.PlayOneShot(o9, 1);
                break;
            case 10:
                aSource.PlayOneShot(o10, 1);
                break;
            case 11:
                aSource.PlayOneShot(o11, 1);
                break;
        }
    }
    /// <summary>
    /// zabiera zycie i podrzuca
    /// </summary>
    /// <param name="bumpAmount"></param>
    public void DamagePlayer(float bumpAmount)
    {
        LoseLife();
        BumpUpCustom(bumpAmount);
        ZagrajDzwiekObrazen();
    }

    public void PlayOChollera()
    {
        if(aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(ochollera, 0.3f);
    }
    public void PlayKurwaKnurze()
    {
        aSource.PlayOneShot(kurwaknurze, 1);
    }
    public void PlayJakKurwaZapierdolilem()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(jakkurwazapierdolilemtokurwazwersalkispadali, 2);
    }
    public void PlayOdpierdolsiekurwa()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(odpierdolsiekurwa, 1);
    }
    public void PlayDobrzeZeKupilem()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(dobrzezekupilem, 1);
    }
    public void PlayNiemamProwoJazdy()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(niemamprowojazdy, 1);
    }
    public void PlayBoZarazRozwaleKamere()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(bozaraztorozwaletakamere, 1);
    }
    public void PlayTakiePiwoNieNadajeSieDoPicia()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(topiwonienadajesiedopicia, 1);
    }
    public void Playotaksierobi()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(luuuotakrobi, 1);
    }
    public void PlayPsiejebany()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(psiejebany, 1);
    }
    public void PlayJaNieLalus()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(janielalus, 1);
    }
    public void PlayChceMnieDoChoroszczy()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(chcemniedochoroszczywyslac, 1);
    }
    public void PlayWMajrkiNasralem()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(wmajtkinasralemkurwa, 1);
    }
    public void PlayMusialemTwarozekzejsc()
    {
        if (aSource.isPlaying)
        {
            aSource.Stop();
        }
        aSource.PlayOneShot(musialemtwarozekzjesc, 1);
    }

    void ZagrajDzwiekObrazen()
    {
        aSource.PlayOneShot(dzwiekObrazen, 1);
    }
    void ZagrajDzwiekZbieraniaBroni()
    {
        aSource.PlayOneShot(dzwiekZebraniaBroni, 1);
    }




    
   public void AddHP_debug()
    {
        liczba_zyc++;
        m_liczba_zyc.text = "" + liczba_zyc;
    }

}
