using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class szczur_wodny : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    private Player player;//skrypt

    public GameObject groundChecker1, groundChecker2;
    public GameObject checker1, checker2, checker3; //for player above

    private bool isPlayerWithinRange;
    public GameObject playerRangeChecker;

    private Vector3 direction;
    public float speed;

    private int lives;

    private Animator anim;

    private enum State { normal, fast}
    private State _state;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent < Player > (); //skrypt
        direction = Vector3.left;
        lives = 2;
        StartCoroutine(Helper());
        StartCoroutine("WaitForCounting");
        anim = GetComponent<Animator>();
        _state = State.normal;
    }
    float x;
    // Update is called once per frame
    void Update()
    {
        
        isPlayerWithinRange = playerRangeChecker.GetComponent<CircleCollider2D>().IsTouchingLayers(playerLayer);

        if (!IsGrounded())//fall
        {
            x = 1;
            transform.position -= new Vector3(0, x, 0) * Time.deltaTime * 4;
            x += .1f;
        }
        else
        {
            x = 1;
            StopCoroutine("CountToDestroy");
            StartCoroutine(WaitForCounting());
        }

            

        transform.position += direction * speed * Time.deltaTime;

        if(IsObstacleOnLeft())
        {
            direction = Vector3.right;
            if(_state == State.normal) anim.SetTrigger("patrolRight");
            else if(_state == State.fast) anim.SetTrigger("chaseRight");

        }
        else if(IsObstacleOnRight())
        {
            direction = Vector3.left;
            if (_state == State.normal) anim.SetTrigger("patrolLeft");
            else if (_state == State.fast) anim.SetTrigger("chaseLeft");
        }

        if(isPlayerWithinRange)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("PatrolLEFT"))
            {
                anim.SetTrigger("chaseLeft");
            }
            else if(anim.GetCurrentAnimatorStateInfo(0).IsName("PatrolRIGHT"))
            {
                anim.SetTrigger("chaseRight");
            }
        }
      

    }
    public bool IsGrounded() //checks if is touching the ground
    {

        Vector3 direction = Vector3.down;
        float distance = .2f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker1.transform.position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(groundChecker2.transform.position, direction, distance, groundLayer);
        if ((hit1.collider != null) || (hit2.collider != null))
        {
            return true;
        }

        return false;
    }
    public bool IsPlayerAbove() //checks if is touching the ground
    {

        Vector3 direction = Vector3.up;
        float distance = 1.0f;

        RaycastHit2D hit1 = Physics2D.Raycast(checker1.transform.position, direction, distance, playerLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(checker2.transform.position, new Vector3(-1, 1, 0), distance - .3f, playerLayer);
        RaycastHit2D hit4 = Physics2D.Raycast(checker2.transform.position, new Vector3(1,1,0), distance - .3f, playerLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(checker3.transform.position, direction, distance, playerLayer);
        if ((hit1.collider != null) || (hit2.collider != null) || (hit3.collider != null) ||(hit4.collider != null))
        {
            return true;
        }

        return false;

    }
    private void OnDrawGizmosSelected() //for debug
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(checker1.transform.position, checker1.transform.position + Vector3.up);
        Gizmos.DrawLine(checker3.transform.position, checker3.transform.position + Vector3.up);
        Gizmos.DrawRay(checker2.transform.position, new Vector3(-1, 1, 0));
        Gizmos.DrawRay(checker2.transform.position, new Vector3(1, 1, 0));
    }
    bool IsObstacleOnLeft()
    {

        Vector3 direction = Vector3.left;
        float distance = .1f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker1.transform.position, direction, distance, groundLayer);
        
        if (hit1.collider != null)
        {
            return true;
        }

        return false;
    }
    bool IsObstacleOnRight()
    {

        Vector3 direction = Vector3.right;
        float distance = .1f;

        RaycastHit2D hit1 = Physics2D.Raycast(groundChecker2.transform.position, direction, distance, groundLayer);

        if (hit1.collider != null)
        {
            return true;
        }

        return false;
    }
    bool isFlicking;
    public IEnumerator Flick()
    {
        isFlicking = true;
        for (int i = 0; i < 7; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        isFlicking = false;
        yield break;
    }
    IEnumerator Helper()
    {
        yield return new WaitUntil(() => isPlayerWithinRange == true);
        speed *= 2;
        _state = State.fast;
        yield return null;
    }
    IEnumerator WaitForCounting()
    {
        yield return new WaitUntil(() => IsGrounded() == false);
        StartCoroutine("CountToDestroy");
        yield break;
    }
    IEnumerator CountToDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject.transform.parent.gameObject);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(IsPlayerAbove())
            {
                if (!isFlicking)
                {
                    StartCoroutine(Flick());
                    lives--;
                    if(lives == 0)
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    player.velocity.y += 15;
                }
            }
            else
            {
                player.DamagePlayer(5);
                //jakis tekst o szczurze
            }
          
            
        }
    }
}
