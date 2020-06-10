using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_up_down_movement : MonoBehaviour
{

    public float speed = 0.0001f;
    private bool movingLeft;
    private bool movingRight;
    private bool noDirection;

   


    public GameObject waypoint1; // left one!
    public GameObject waypoint2; // right one!

    

    private Transform t1; //transfors for waypoints
    private Transform t2;

   
   






    void Start()
    {
        t1 = waypoint1.GetComponent<Transform>();
        t2 = waypoint2.GetComponent<Transform>();
        noDirection = true;
        movingLeft = false;
        movingRight = false;
        
       

    }

    void Update()
    {
        ////////////////////////PATROL//////////////////////////////
        float step = speed * Time.deltaTime;

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
        //////////////////////////ANIMATIONS///////////////////////////////////////////////////////////

      


    }

  



  
}
