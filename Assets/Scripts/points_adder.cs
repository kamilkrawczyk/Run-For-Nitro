using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class points_adder : MonoBehaviour {

    private TextMeshProUGUI m_Text;
    private int points;
    private const int points_for_zubr = 1;
    private const int points_for_coal = 2;
    private const int points_for_parcel = 5;
    private const int points_for_food = 10;
    private const int points_for_bombassoldier = 50;

    private const int points_for_knur = 5;
    private const int points_for_chomincz = 10;
    private const int points_for_lalus = 15;
    private const int points_for_szczurWodny = 20;
    private const int points_for_marioBOSS = 50;
    private const int points_for_neroBOSS = 60;
    private const int points_for_lastBOSS = 100;


    //------------------MAJOR CLIPS--------------------------------//
    [Header("Collection Clips")]
    public AudioClip piwkotojestjakrosol;
    public AudioClip bialostockiepiwojesnajlepsze;
    public AudioClip janieuzywamolkoholu;
    public AudioClip janiejestempijakiemtylkochcemsprobowac;
    public AudioClip zubrjestnajlepszy;

    public AudioClip wegielnadajesiedopalenia;
    public AudioClip komubrakujewegla;
    public AudioClip takiwegielwygladajakzloto;

    public AudioClip amowiazejaptasibrzuch;
    public AudioClip zebyjesctrzebazyc;
    public AudioClip otaksieje;

    public AudioClip kurierwlasnieprzywiozlpaczke;
    public AudioClip jacywidzowiesaspaniali;
    public AudioClip przyjechalsamochodzpaczka;

    public AudioClip jajakosabymuzadlil;

    public AudioClip nasraldowiaderka;
    //-------------------SOUND EFFECTS-------------------------/
    [Header("Sound Effects")]
    public AudioClip eight_bitCollection;
    [Space]
    public float volume = 0.5f;
    AudioSource asource;


	void Start () {
        m_Text = GetComponent<TextMeshProUGUI>();
        points = 0;
        m_Text.text = "" + points;
        asource = GetComponent<AudioSource>();
	}
   
    void SoundFixxxer()
    {
        if(asource.isPlaying)
        {
            asource.Stop();
        }
    }



    /////////////////////////////////////////////////////////////////////////////////
    
    public void Zubr_collected()
    {
        SoundFixxxer();

        asource.PlayOneShot(eight_bitCollection, volume);

        points = points + points_for_zubr;
        m_Text.text = "" + points;

        int soundRandomizer;
        soundRandomizer = Random.Range(1, 6);
        switch(soundRandomizer)
        {
            case 1:
                asource.clip =piwkotojestjakrosol;
                break;
            case 2:
                asource.clip = bialostockiepiwojesnajlepsze;
                break;
            case 3:
                asource.clip = janieuzywamolkoholu;
                break;
            case 4:
                asource.clip = janiejestempijakiemtylkochcemsprobowac;
                break;
            case 5:
                asource.clip = zubrjestnajlepszy;
                break;
        }
        asource.PlayDelayed(.2f);
       
    }
    public void Coal_collected()
    {
        SoundFixxxer();
        asource.PlayOneShot(eight_bitCollection, volume);

        points = points + points_for_coal;
        m_Text.text = "" + points;

        int soundRandomizer;
        soundRandomizer = Random.Range(1, 4);
        switch (soundRandomizer)
        {
            case 1:
                asource.PlayOneShot(wegielnadajesiedopalenia, 1.5f);
                break;
            case 2:
                asource.PlayOneShot(komubrakujewegla, 1.5f);
                break;
            case 3:
                asource.PlayOneShot(takiwegielwygladajakzloto, 1.5f);
                break;
         
        }
        
    }
    public void Parcel_collected()
    {
        SoundFixxxer();
        asource.PlayOneShot(eight_bitCollection, volume);

        points = points + points_for_parcel;
        m_Text.text = "" + points;

        int soundRandomizer;
        soundRandomizer = Random.Range(1, 4);
        switch (soundRandomizer)
        {
            case 1:
                asource.clip = kurierwlasnieprzywiozlpaczke;
                break;
            case 2:
                asource.clip = jacywidzowiesaspaniali;
                break;
            case 3:
                asource.clip = przyjechalsamochodzpaczka;
                break;
        }
        asource.PlayDelayed(.2f);

    }
    public void Food_collected()
    {
        SoundFixxxer();
        asource.PlayOneShot(eight_bitCollection, volume);

        points = points + points_for_food;
        m_Text.text = "" + points;

        int soundRandomizer;
        soundRandomizer = Random.Range(1, 4);
        switch (soundRandomizer)
        {
            case 1:
                asource.clip =zebyjesctrzebazyc;
                break;
            case 2:
                asource.clip =amowiazejaptasibrzuch;
                break;
            case 3:
                asource.clip = otaksieje;
                break;
        }
        asource.PlayDelayed(.2f);
       
    }
    public void Bombassoldier_collected()
    {
        SoundFixxxer();
        asource.PlayOneShot(eight_bitCollection, volume);

        points = points + points_for_bombassoldier;
        m_Text.text = "" + points;

        asource.clip = jajakosabymuzadlil;
        asource.PlayDelayed(.2f);


        
    }
    public void ShitParcel_collected()
    {
        SoundFixxxer();

        points = points + 100;
        asource.PlayOneShot(nasraldowiaderka, 1.2f);
        m_Text.text = "" + points;

        
    }
    /// <summary>
    /// wpisz: knur, chomincz, lalus, szczur, mario, nero, kononolos. tylko dodaje punkty!
    /// </summary>
    /// <param name="enemy"></param>
    public void EnemyDefeated(string enemy)
    {
        switch(enemy)
        {
            case "knur":
                points = points + points_for_knur;
                m_Text.text = "" + points;
                break;
            case "chomincz":
                points = points + points_for_chomincz;
                m_Text.text = "" + points;
                break;
            case "lalus":
                points = points + points_for_lalus;
                m_Text.text = "" + points;
                break;
            case "szczur":
                points = points + points_for_szczurWodny;
                m_Text.text = "" + points;
                break;
            case "mario":
                points = points + points_for_marioBOSS;
                m_Text.text = "" + points;
                break;
            case "nero":
                points = points + points_for_neroBOSS;
                m_Text.text = "" + points;
                break;
            case "kononolos":
                points = points + points_for_lastBOSS;
                m_Text.text = "" + points;
                break;
            default:
                Debug.Log("nieprawidlowa zmienna string w metodzie EnemyDefeated");
                break;
        }
    }
}
