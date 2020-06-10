using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piwo_0_pulapka : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public bool moveUpAndDown;

    public GameObject animEffect;
    private GameObject player;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveUpAndDown)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        animEffect.SetActive(true);
        player.GetComponent<Player>().PlayTakiePiwoNieNadajeSieDoPicia();
        player.GetComponent<Player>().DamagePlayer(4);
        Invoke("Die", 0.2f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
