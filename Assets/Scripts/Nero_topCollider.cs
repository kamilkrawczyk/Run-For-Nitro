using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nero_topCollider : MonoBehaviour
{
    public GameObject Nero;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //jak gracz mu na glowe skoczy
        {
            if(player.transform.position.y > Nero.transform.position.y)
            {
                if(isFlicking)
                {
                    player.GetComponent<Player>().velocity.y += 15;
                }
                else
                {
                    Nero.GetComponent<nero_controller>().healthBar.GetComponent<Image>().fillAmount -= 0.13f;
                    player.GetComponent<Player>().velocity.y += 10;
                    StartCoroutine(Flick());
                }            
            }
        }
    }
    public bool isFlicking;
    public IEnumerator Flick()
    {
        isFlicking = true;
        for(int i=0; i<7; i++)
        {
            Nero.GetComponent<SpriteRenderer>().enabled = false;          
            yield return new WaitForSeconds(.1f);
            Nero.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        isFlicking = false;
        yield break;
    }

}
