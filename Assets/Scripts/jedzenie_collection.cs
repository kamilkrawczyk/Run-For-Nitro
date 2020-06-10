using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jedzenie_collection : MonoBehaviour
{

    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public points_adder pointsadder;

    public GameObject plusTen;
    public GameObject clicker;




    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    // Use this for initialization
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            pointsadder.Food_collected();
            plusTen.SetActive(true);
            clicker.SetActive(true);
            Destroy(gameObject);
        }

    }
}
