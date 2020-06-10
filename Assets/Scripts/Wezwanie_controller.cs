using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Wezwanie_controller : MonoBehaviour
{
    [SerializeField]
    private GameObject dirController;
    public  GameObject disSprite;
    public GameObject parentToDestroy;
    private GameObject player;
    public GameObject flyingAnimObj;


    public float speed = 1;
    private bool isMoving;

    private Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
       

        player = GameObject.FindGameObjectWithTag("Player");

        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        dir = dirController.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, dirController.transform.position, step);
        }
             
        if(transform.position == dirController.transform.position) //jesli dolecial do waypointu
        {
            StartCoroutine(Die());
        }

    }
    IEnumerator Die()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        flyingAnimObj.SetActive(false);
        disSprite.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(parentToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isMoving = false;
            flyingAnimObj.SetActive(false);
            player.GetComponent<Player>().BumpUpCustom(8);
            player.GetComponent<Player>().LoseLife();
            player.GetComponent<Player>().PlayChceMnieDoChoroszczy();
            StartCoroutine(Die());
        }
    }
}
