using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class zubr_collection : MonoBehaviour {

    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    private points_adder pointsadder;

    public GameObject plusOne;
    public GameObject clicker;

    public bool czyJestKsiezycowy;


    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    // Use this for initialization
    void Start ()
    {
        pointsadder = GameObject.FindGameObjectWithTag("Liczba_punktow").GetComponent < points_adder > ();   
        posOffset = transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(!czyJestKsiezycowy)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }else
        {
            transform.Rotate(0, 0, 20);
            transform.position += Vector3.down * 3 * Time.deltaTime;
        }
          
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
            pointsadder.Zubr_collected();
            plusOne.SetActive(true);
            clicker.SetActive(true);
            Destroy(gameObject);                     
        }
    
    }
    
}
