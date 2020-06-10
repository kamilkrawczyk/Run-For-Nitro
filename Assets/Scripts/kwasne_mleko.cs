using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kwasne_mleko : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Destroy", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -0.06f, 0);

    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Player>().DamagePlayer(5);
            //dzwiek zrobic
        }
    }
}
