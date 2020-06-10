using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kononoLos_controller : MonoBehaviour
{
    Animator anim;
    public Image healthBar;
    public GameObject playerDirectionChecker;
    public GameObject spot1, spot2;
    public GameObject axePrefab, policeCarPrefab, knurPrefab, puffPrefab;
    public GameObject carSpawnPos;
    public GameObject puff;
    public GameObject summonSpot1, summonSpot2;

    public bool isPlayerOnTheLeft;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isPlayerOnTheLeft = true;

        StartCoroutine("Pattern1");
        StartCoroutine(LookForTransision());

    }

    // Update is called once per frame
    void Update()
    {
        isPlayerOnTheLeft = playerDirectionChecker.GetComponent<isPlayerOnLeftOrRight_checker>().isPlayerOnLeft;
    }

    IEnumerator Pattern1()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            SummonKnur();
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true);
            yield return new WaitForSeconds(1);
            //
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true);
            yield return new WaitForSeconds(2);
            //
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true);
            yield return new WaitForSeconds(1);
        }            
    }
    IEnumerator Pattern2()
    {
        StartCoroutine(Puff());
        anim.SetTrigger("newState");
        yield return new WaitForSeconds(1);

        //dialog zlosiem

        while(true)
        {

        }       
    }
    IEnumerator LookForTransision()
    {
        yield return new WaitUntil(() => healthBar.fillAmount <= .02f);
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") == true);
        StopCoroutine("Pattern1");
        StartCoroutine("Pattern2");
        yield break;
    }

    ////BEHAVIOURS 1/////----------------------------------------------------------------------------------------
    void MoveLeft1() //moves left a bit
    {
        anim.SetTrigger("runLeft1");
    }
    void MoveRight1() //moves right the same bit
    {
        anim.SetTrigger("runRight1");
    }
    void DrinkMilk()
    {
        anim.SetTrigger("drinkMilk");
    }
    void ThrowAxeAtPlayer()
    {
        if(isPlayerOnTheLeft)
        {
            anim.SetTrigger("throwLeft1");
            ThrowAxeInstantiate("left");
        }else if(!isPlayerOnTheLeft)
        {
            anim.SetTrigger("throwRight1");
            ThrowAxeInstantiate("right");
        }
    }
    void CallThePolice()
    {
        anim.SetTrigger("dzwonNaPolicje");
        Invoke("InstantiateCopCar", 1);
        Invoke("GoBackToIdle1", 4);
    }
    void Cry()
    {
        anim.SetTrigger("placz");
    }
    void SummonKnur()
    {
        anim.SetTrigger("summonKnur");
        Invoke("SummonKnurs", 2);
    }


    
    /// //////////////////////////////////////////////////////////////////////////////////////////////
    void ThrowAxeInstantiate(string direction)//left or right // chyba bedzie poprawka lustra osi X
    {
        if(direction == "left")
        {
            GameObject axe =Instantiate(axePrefab, spot1.transform.position, axePrefab.transform.rotation);
            axe.GetComponent<Enemy_throw>().orientation = Enemy_throw.Orientation.Left;
        }
        else if(direction == "right")
        {
            GameObject axe2 = Instantiate(axePrefab, spot2.transform.position, axePrefab.transform.rotation);
            axe2.GetComponent<Enemy_throw>().orientation = Enemy_throw.Orientation.Right;
        }
    }
    void InstantiateCopCar()
    {
        GameObject car = Instantiate(policeCarPrefab, carSpawnPos.transform.position, policeCarPrefab.transform.rotation);
    }
    void SummonKnurs()
    {
        StartCoroutine(SummonPuff(summonSpot1.transform.position)); StartCoroutine(SummonPuff(summonSpot2.transform.position));
        GameObject knur1 = Instantiate(knurPrefab, summonSpot1.transform.position, knurPrefab.transform.rotation);
        GameObject knur2 = Instantiate(knurPrefab, summonSpot2.transform.position, knurPrefab.transform.rotation);
    }
    IEnumerator SummonPuff(Vector3 position)
    {
        GameObject _puff = Instantiate(puffPrefab, position, puffPrefab.transform.rotation);
        yield return new WaitForSeconds(1);
        Destroy(_puff);
        yield return null;
    }
    IEnumerator Puff() //ten obiekt
    {
        puff.SetActive(true);
        yield return new WaitForSeconds(1);
        puff.SetActive(false);
        yield return null;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, Vector3.left * 5);
    }
    public void GoBackToIdle1()
    {
        anim.SetTrigger("idle1");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
