using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_to_throw : MonoBehaviour
{
    private GameObject player;
    public GameObject hitMarker, jebak, puff;
    private bool rotate;

    private AudioSource aSource;
    public AudioClip a1, a2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = true;
        Invoke("Die", 7);
        jebak = GameObject.FindGameObjectWithTag("Jebak");
    }

    public enum Orientation { Left, Right }
    public Orientation orientation;

    private float movementMultiplier = 6.5f;


    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            if (orientation == Orientation.Left)
            {
                gameObject.transform.Rotate(0, 0, 20);
                gameObject.transform.position += Vector3.left * movementMultiplier * Time.deltaTime;
            }
            else if (orientation == Orientation.Right)
            {
                gameObject.transform.Rotate(0, 0, -20);
                gameObject.transform.position += Vector3.right * movementMultiplier * Time.deltaTime;
            }
        }
    }  
   public void EnemyHit()
    {
        hitMarker.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Die", .5f);
        rotate = false;
    }
    public void Puff()
    {
        puff.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Die", .5f);
        rotate = false;
    }
 


    void Die()
    {
        Destroy(gameObject);
    }
}
   
    

