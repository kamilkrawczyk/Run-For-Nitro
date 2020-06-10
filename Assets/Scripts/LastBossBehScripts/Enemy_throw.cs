using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_throw : MonoBehaviour
{
    private Player playerScript;
    public GameObject puff;
    private bool rotate;




    public enum Orientation { Left, Right }
    public Orientation orientation;

    public float movementMultiplier = 3;
    public int rotationSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rotate = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (rotate)
        {
            if (orientation == Orientation.Left)
            {
                gameObject.transform.Rotate(0, 0, rotationSpeed);
                gameObject.transform.position += Vector3.left * movementMultiplier * Time.deltaTime;
            }
            else if (orientation == Orientation.Right)
            {
                gameObject.transform.Rotate(0, 0, -rotationSpeed);
                gameObject.transform.position += Vector3.right * movementMultiplier * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript.DamagePlayer(5);
            //play sound
            rotate = false;//stop
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            puff.SetActive(true);
            StartCoroutine(WaitForDeath());

        }
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield break;
    }

}


