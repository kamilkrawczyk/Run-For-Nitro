using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform : MonoBehaviour
{

    public bool shake;
    private Animator anim;
    private bool startFalling;
    public GameObject trigger;
    private float x;
    public float timeToFall;

    Vector3 point1, point2;
    private float speed = 2.5f;

    private bool movingLeft;
    private bool movingRight;
    private bool noDirection;

    // Start is called before the first frame update
    void Start()
    {
        shake = false;
        anim = GetComponent<Animator>();
        x = -0.08f;
        point1 = transform.position - new Vector3(.06f, 0, 0);
        point2 = transform.position + new Vector3(.06f, 0, 0);
        noDirection = true;
        movingLeft = false;
        movingRight = false;
    }
    bool stopper1;
    bool fall;
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (shake)
        {
            if(!stopper1)
            {
                StartCoroutine(Fall());
                stopper1 = true;
            }
            
            if (noDirection == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, point1, step ); // podziel step zeby zmienic predkosc
                if (transform.position == point1)
                {
                    noDirection = false;
                    movingRight = true;
                }
            }
            if (movingRight == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, point2, step );
                if (transform.position == point2)
                {
                    movingRight = false;
                    movingLeft = true;
                }
            }
            if (movingLeft == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, point1, step );
                if (transform.position == point1)
                {
                    movingLeft = false;
                    movingRight = true;
                }
            }

        }
        if(fall)
        {
            transform.position += new Vector3(0, x, 0);
            x -= 0.005f;
        }

    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        shake = false; //stop shaking
        fall = true;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);                
    }
   

    
}
  
   
