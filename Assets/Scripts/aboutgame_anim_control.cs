using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aboutgame_anim_control : MonoBehaviour
{
    public GameObject ramkaprzyKononiel, typeWriter, konon;
    public Texture kononDoResetu;

 

    IEnumerator AnimationSteps()
    {
        yield return new WaitForSeconds(3);
        ramkaprzyKononiel.SetActive(true);
        StartCoroutine(typeWriter.GetComponent<typewriter_effect>().ShowText(" "));
        yield return new WaitForSeconds(2);
        StartCoroutine(typeWriter.GetComponent<typewriter_effect>().ShowText("W glowie sie kreci sie...."));
        yield return new WaitForSeconds(4);
        ramkaprzyKononiel.SetActive(false);
        yield return new WaitForSeconds(.5f);
        konon.GetComponent<Animator>().enabled = true;

    }
    public void StartCorout()
    {
        StartCoroutine(AnimationSteps());
    }
    public void ResetTexture()
    {
        konon.GetComponent<RawImage>().texture = kononDoResetu;
    }
    public void DisableKononAnim()
    {
        konon.GetComponent<Animator>().enabled = false;
    }
}
