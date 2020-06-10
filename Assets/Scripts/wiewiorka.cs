using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiewiorka : MonoBehaviour
{
    private bool canCatch, n_caught;
    public GameObject waypoint1, parent, tree, puff;
    private GameObject player;
    public float radius;
    public float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        n_caught = true;
    }

    // Update is called once per frame
    bool stopper1;
    void Update()
    {
        if(n_caught)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(player.transform.position, transform.position) < radius)
            {
                canCatch = true;
            }
            if (canCatch)
            {
                if (!stopper1)
                {
                    gameObject.GetComponent<Animator>().SetTrigger("Run");
                    stopper1 = true;
                }
                transform.position = Vector3.MoveTowards(transform.position, waypoint1.transform.position, step);
                if (transform.position == waypoint1.transform.position)//wp1 reached
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    tree.GetComponent<Animator>().enabled = true;
                    Invoke("Die", 3);
                }
            }
        }          
    }
    void Die()
    {
        Destroy(gameObject);
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Strus")
        {
            n_caught = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            puff.SetActive(true);
            Invoke("Die", .5f);
        }
    }
}
