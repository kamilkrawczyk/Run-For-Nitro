using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typewriter_effect : MonoBehaviour { //controller for typing in dialogue boxes

    
    private string currentText = "";
    private TextMeshProUGUI m_text;
    public bool isRunning = false;
    [SerializeField]
    float timeBeetwenLetters = 0.02f;

    private AudioSource aSource;
    

    // Use this for initialization
    void Start () {
        m_text = GetComponent<TextMeshProUGUI>();
        aSource = GetComponent<AudioSource>();
       
	}

   
    public IEnumerator ShowText(string text) 
    {
        
        aSource.Play();
        for(int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            m_text.text = currentText;
            yield return new WaitForSeconds(timeBeetwenLetters);          
        }
        aSource.Stop();
       
    }
    public void ClearField()
    {        
        currentText = "";
        m_text.text = currentText;
    }
  
}
