using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class number_of_cups_UI : MonoBehaviour {


    private TextMeshProUGUI m_Text;
    public int number_of_cups;

    AudioSource aSource;
    public AudioClip wyjebaccitymkubkiem;
    public float volume = 1.5f;

	// Use this for initialization
	void Start () {
        m_Text = GetComponent<TextMeshProUGUI>();
        number_of_cups = 0;
        m_Text.text = "" +number_of_cups;
        aSource = GetComponent<AudioSource>();

    }
	
	

    public void Cup_collected_plusOne()
    {      
        number_of_cups++;
        m_Text.text = "" + number_of_cups;
        aSource.PlayOneShot(wyjebaccitymkubkiem, volume);
    }
    public void Cup_collected_plusThree()
    {
        number_of_cups += 3;
        m_Text.text = "" + number_of_cups;
        aSource.PlayOneShot(wyjebaccitymkubkiem, volume);
    }
    public void Cup_collected_plusFive()
    {
        number_of_cups += 5;
        m_Text.text = "" + number_of_cups;
        aSource.PlayOneShot(wyjebaccitymkubkiem, volume);
    }

    public void Cup_thrown()
    {
        number_of_cups--;
        m_Text.text = "" + number_of_cups;

    }
}
