using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class levelselector_showtexts : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject czerwonaramka1, szararamka2, szararamka3, szararamka4;

    public void OnPointerEnter(PointerEventData eventData)
    {
       if(gameObject.CompareTag("button1"))
        {
            czerwonaramka1.SetActive(true);
        }
        if(gameObject.CompareTag("button2"))
        {
            szararamka2.SetActive(true);
        }
        if (gameObject.CompareTag("button3"))
        {
            szararamka3.SetActive(true);
        }
        if (gameObject.CompareTag("button4"))
        {
            szararamka4.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.CompareTag("button1"))
        {
            czerwonaramka1.SetActive(false);
        }
        if (gameObject.CompareTag("button2"))
        {
            szararamka2.SetActive(false);
        }
        if (gameObject.CompareTag("button3"))
        {
            szararamka3.SetActive(false);
        }
        if (gameObject.CompareTag("button4"))
        {
            szararamka4.SetActive(false);
        }
    }




}
