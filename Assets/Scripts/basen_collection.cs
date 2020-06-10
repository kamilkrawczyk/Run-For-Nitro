using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basen_collection : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    public GameObject basenUI, a_nimation;

    [SerializeField]
    public GameObject poolSpawner;
   

    // Start is called before the first frame update
    void Start()
    {       
        posOffset = transform.position;
        basenUI = GameObject.FindGameObjectWithTag("pool");
        
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            basenUI.GetComponent<RawImage>().enabled = true;
            a_nimation.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;           
            Invoke("Die", 1);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
