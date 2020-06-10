using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kubek_throw_right : MonoBehaviour {

    private int speed = 15;

    private Vector3 moveVector;
    private Vector3 startingVector = new Vector3(0.5f, 0.5f, 0);

    public GameObject controller, hitMarker;
    public LayerMask ground;
    private bool IsMovingLeft = false, rotate;

    private void Start()
    {
        moveVector = startingVector;
        Invoke("Die", 4);
        rotate = true;
    }
    public void EnemyHit()
    {
        hitMarker.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Die", .5f);
        rotate = false;
    }





    //-------------------GROUND CHECKERS----------------------------------------
    bool IsTouchingGroundDown()
    {
        Vector3 direction = Vector3.down;
        float distance = 0.3f;
        RaycastHit2D hit1 = Physics2D.Raycast(controller.transform.position, direction, distance, ground);
        if (hit1.collider != null)
        {
            return true;
        }
        return false;
    }
    bool IsTouchingGroundLeft()
    {
        Vector3 direction = Vector3.left;
        float distance = 0.3f;
        RaycastHit2D hit1 = Physics2D.Raycast(controller.transform.position, direction, distance, ground);
        if (hit1.collider != null)
        {
            return true;
        }
        return false;
    }
    bool IsTouchingGroundRight()
    {
        Vector3 direction = Vector3.right;
        float distance = 0.3f;
        RaycastHit2D hit1 = Physics2D.Raycast(controller.transform.position, direction, distance, ground);
        if (hit1.collider != null)
        {
            return true;
        }
        return false;
    }
    //--------------------------------------------------------------------------

    private void Update()
    {
        if(rotate)
        {
            transform.Rotate(0, 0, -30); // around itself

            moveVector = moveVector - new Vector3(0, 0.02f, 0); //fall, change vector to point downwards

            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);//movement

            if (IsTouchingGroundDown() == true)
            {
                if (IsMovingLeft == true)
                {
                    moveVector = new Vector3(0.5f, 0.5f, 0);
                }
                else
                {
                    moveVector = startingVector;
                }

            }
            if (IsTouchingGroundLeft() == true)
            {
                moveVector = new Vector3(0.5f, 0.5f, 0);
                IsMovingLeft = false;
            }
            if (IsTouchingGroundRight() == true)
            {
                moveVector = new Vector3(-0.5f, 0.5f, 0);
                IsMovingLeft = true;
            }
        }      
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}