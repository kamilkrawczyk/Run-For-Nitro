using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lusterko_lalusia : MonoBehaviour
{
    private GameObject player;
    public GameObject animationSprite, disappearSprite;
    private bool rotate, startGoingFurther;

    public Vector3 playerLocation; //is already here

    private Vector3 movementVector = Vector3.zero; //for moving further



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = true;
        Invoke("Die", 4.2f);
        movementVector = (playerLocation - transform.position).normalized;

    }

    public enum Orientation { Left, Right }
    public Orientation orientation;

    


    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            if (orientation == Orientation.Left)
            {
                gameObject.transform.Rotate(0, 0, 5);
                transform.position = Vector3.MoveTowards(transform.position, playerLocation, 3 * Time.deltaTime);                
                if (Vector3.Distance(transform.position, playerLocation) < .3f) //dolecial do pozycji gracza
                {
                    startGoingFurther = true;
                }
                
               
            }
            else if (orientation == Orientation.Right)
            {
                gameObject.transform.Rotate(0, 0, -5);
                transform.position = Vector3.MoveTowards(transform.position, playerLocation, 3 * Time.deltaTime);
                if (Vector3.Distance(transform.position, playerLocation) < .3f) //dolecial do pozycji gracza
                {
                    startGoingFurther = true;
                }

            }

            if(startGoingFurther)
            {
                transform.position += movementVector * 6 * Time.deltaTime; //go further                          
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Player>().LoseLife();
            player.GetComponent<Player>().BumpUpCustom(3);
          
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;                      
        }
    }
    void Die()
    {     
        Destroy(gameObject);
    }
}
