using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piwo_bezalkoholowe : MonoBehaviour
{
    private GameObject player;
    public GameObject hitMarker;
    Vector3 flyDir;
    float flySpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 20);
        gameObject.transform.position += flyDir * flySpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Player>().DamagePlayer(4.5f);
            player.GetComponent<Player>().PlayTakiePiwoNieNadajeSieDoPicia();
            hitMarker.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Die", .5f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void SetFlySettings(Vector3 direction, float speed)
    {
        flyDir = direction;
        flySpeed = speed;
    }
}
