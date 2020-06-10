using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prawko : MonoBehaviour
{
    private GameObject player;
    public GameObject animationSprite;
    private bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = true;
        Invoke("Die", 5);
    }

    public enum Orientation {Left, Right}
    public Orientation orientation;

    public float movementMultiplier = 3;


    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            if (orientation == Orientation.Left)
            {
                gameObject.transform.Rotate(0, 0, 8);
                gameObject.transform.position += Vector3.left * movementMultiplier * Time.deltaTime;
            }
            else if (orientation == Orientation.Right)
            {
                gameObject.transform.Rotate(0, 0, -8);
                gameObject.transform.position += Vector3.right * movementMultiplier * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Player>().DamagePlayer(5);
           
            player.GetComponent<Player>().PlayNiemamProwoJazdy();
            animationSprite.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rotate = false; 
            Invoke("Die", .4f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
