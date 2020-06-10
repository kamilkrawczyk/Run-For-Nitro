using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twarozek : MonoBehaviour
{

    public GameObject player;
    public enum Orientation { Left, Right, Down, Up }
    public Orientation orientation;
    public float rotationSpeed, movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Destroy", 8f);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(orientation == Orientation.Down)
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.position += new Vector3(0, -movementSpeed, 0) * Time.deltaTime;
        }
        else if (orientation == Orientation.Up)
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.position += new Vector3(0, movementSpeed, 0) * Time.deltaTime;
        }
        else if (orientation == Orientation.Left)
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.position += new Vector3(-movementSpeed, 0, 0) * Time.deltaTime;
        }
        else if (orientation == Orientation.Right)
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.position += new Vector3(movementSpeed,0 , 0) * Time.deltaTime;
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(orientation == Orientation.Left || orientation == Orientation.Right)
            {
                player.GetComponent<Player>().DamagePlayer(6);
                player.GetComponent<Player>().LoseLife();
            }
            else
            {
                player.GetComponent<Player>().LoseLife();
                player.GetComponent<Player>().BumpLeft();
            }
            player.GetComponent<Player>().PlayWMajrkiNasralem();
        }
    }
}
