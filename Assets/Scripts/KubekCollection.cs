using UnityEngine;
using System.Collections;
using TMPro;


public class KubekCollection : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    private GameObject player;

    public GameObject floatingNumber;
    public GameObject _animation;
    

   
    
    

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && gameObject.tag == "KubekToCollect+1")
        {
            player.GetComponent<Player>().AddCups(1);
            gameObject.SetActive(false);
            floatingNumber.SetActive(true);
            _animation.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "KubekToCollect+3")
        {
            player.GetComponent<Player>().AddCups(3);
            gameObject.SetActive(false);
            floatingNumber.SetActive(true);
            _animation.SetActive(true);
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "KubekToCollect+5")
        {
            player.GetComponent<Player>().AddCups(5);
            gameObject.SetActive(false);
            floatingNumber.SetActive(true);
            _animation.SetActive(true);
        }
    }

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

        



    }
   
}


	
