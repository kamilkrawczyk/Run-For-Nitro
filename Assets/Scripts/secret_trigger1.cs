using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secret_trigger1 : MonoBehaviour {

    public GameObject wallHolder;
    public GameObject animationHolder;
    public GameObject paczkaZGownem;
    public GameObject triggerToTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wallHolder.SetActive(false);
        animationHolder.SetActive(true);
        paczkaZGownem.SetActive(true);
        triggerToTrigger.SetActive(true);
        Invoke("Die", 3);
    }
  
}
