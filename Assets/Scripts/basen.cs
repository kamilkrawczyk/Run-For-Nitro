using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basen : MonoBehaviour
{
    public GameObject nero;
    public LayerMask groundLayer;
    private float height = .3f;
    private float startYpos;
    private Vector3 dir;
    float multiplier = 5;
    public bool isPoolPresent;
    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(.4f, 1, 0);
        startYpos = gameObject.transform.position.y;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        isPoolPresent = false;
        nero = GameObject.FindGameObjectWithTag("Nero");
        nero.GetComponent<nero_controller>().pool = this.gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsGrounded())
        {
            if (transform.position.y < startYpos + height)
            {
                transform.position += dir * 2 * Time.deltaTime;
            }
            else
            {
                dir = new Vector3(0, -1, 0);
                multiplier += 4f;
                transform.position += dir * multiplier * Time.deltaTime;           
            }
        }
        else
        {
            isPoolPresent = true;                   
        }      
    }
    bool IsGrounded() //checks if player is touching the ground
    { 
        Vector3 direction = Vector3.down;
        float distance = .5f;
        RaycastHit2D hit1 = Physics2D.Raycast(gameObject.transform.position, direction, distance, groundLayer);     
        if (hit1.collider != null)
        {
            
            return true;
            
        }
        return false;
    }
    private void OnDestroy()
    {
        isPoolPresent = false;
    }
}
