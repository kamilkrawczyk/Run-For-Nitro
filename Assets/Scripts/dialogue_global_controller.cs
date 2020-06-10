using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogue_global_controller : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject dialogueUI;
    public GameObject typewriter;
    private GameObject player;
    private Player playerScript;
    public int whichText; //11 for window 1 text 1 , 24 for window 2 text 4 etc
    public GameObject portrait;
    public GameObject podpis;

    //level1//
    public GameObject cutsceneCanvas1; //use for next leves too
    public GameObject majorPokojBG;
    public GameObject masterController;
    Animator anim1;

    public Texture portretMex;
    public Texture portretMaj;
    public Texture portretTomasz, portretNero, portretMario, portretOrbit;

    public GameObject lvl2_startingCutscenePanel, gameCamera, jejebak;

    private bool canStartJebakFight;
    public GameObject lvl3NERO;
    public GameObject fadeIn;

    [Header("5lvl")]
    public Mastercontroller_5 mastercontroller5;

    public void PortraitChange(Texture tex)
    {
        RawImage image;
        image = portrait.GetComponent<RawImage>();
        image.texture = tex;
    }
    public void NameChange(string name)
    {
        TextMeshProUGUI m_text;
        m_text = podpis.GetComponent<TextMeshProUGUI>();
        m_text.text = name;
    }








    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        canStartJebakFight = false;
    }

    public void AtTheDialogueStart()
    {
        playerScript.enabled = false;
        dialogueUI.SetActive(true);
        mainUI.SetActive(false);
        player.GetComponent<Animator>().enabled = false;
    }
    //FIRST TYPEs//-----------------------------------------------------------------------------------------------------------------------------------
    public void FirstTypeLvl2_start()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Siemano, siemano, mexicano jest jeden a metrów ma do kibla siedem!!"));
        whichText = 23;
    }
    public void TypeMajorUStopDrabiny()
    {
        NameChange("Major");
        PortraitChange(portretMaj);
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ugułem dziwnie tu pachnie.. muszę mieć lepszq wiadomość..."));
        //gramy muzyke na start
        GameObject master = GameObject.FindGameObjectWithTag("GameController");
        master.GetComponent<mastercontroller_2>().PlayAmbient_void();
        whichText = 0;
    }
    public void MarioPrzedWalka() //trigger przed walka
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("No i cię znalazłem, Majorze. Nareszcie się spotykamy.."));
        whichText = 34;
        canStartJebakFight = true;
    }
    public void VeryStartTrzeciegoLevela()
    {

        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("no ugułem... jakoś tak mam ochotę rozwalić tq kamerę... może ksiek jest w pobliżu..."));
        whichText = 0;
    }
    public void PierwszyRazChomincz()
    {
        NameChange("Profesor Tomasz");
        PortraitChange(portretTomasz);
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Panie Majorze, uwaga! Przed Panem jest Chomincz-chomiczowna! Proszę ją pokonać zanim napisze donos!"));
        whichText = 0;
    }
    public void MexykKibelLvl2()
    {
        NameChange("Profesor Tomasz");
        PortraitChange(portretTomasz);
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Panie Majorze gratulacje, znalazł Pan ukryty kibel Mexyka! Tylko tutaj, pod ziemią może on się bezpłatnie podłączyć do miejskiej kanalizacji.."));
        whichText = 0;
    }
    public void Orbit()
    {
        NameChange("Major");
        PortraitChange(portretMaj);
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText(" "));
        Invoke("Orbit2", .5f);
        whichText = 60;
    }
    void Orbit2()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ooo! Orbit! To on byl Orbitem!!"));
    }
    public void NaKoncuNera()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Aaaa! nero ooo to ty kurwa pusc me psie jebany!!"));
        whichText = 53;
    }
    public void PoczatekKsiezyca()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("oo cholera.. przez to nitro ktore wypilem jestem teras na ksinzycu! musze miec lepszq wiadomosd!!"));
        whichText = 70;
    }
    public void Poczatek5levela()
    {
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("o cholllera... gdzie ja... ja muszw biegnac do domu szypko do kska cale te tak jak mi orbit powiedzial!!"));
        whichText = 71;
    }





    /// <summary>
    /// //////////////----------------------------------------------------------------------------------------------------------------------
    /// </summary>
    public void NextButtonOnClick()
    {
        StopAllCoroutines();
        typewriter.GetComponent<typewriter_effect>().ClearField();
        switch (whichText)
        {
            case 0: //for exiing the dialogue window
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("  "));
                playerScript.enabled = true;
                gameCamera.GetComponent<CameraFollow>().enabled = true;

                dialogueUI.SetActive(false);
                mainUI.SetActive(true);
                player.GetComponent<Animator>().enabled = true;

                Cursor.visible = false;

                //jesli jest jejebak to zacznij walke i odpal muze
                if (canStartJebakFight && jejebak != null)
                {
                    jejebak.GetComponent<jejebak>().StartFight();
                    GameObject master = GameObject.FindGameObjectWithTag("GameController");
                    master.GetComponent<mastercontroller_3>().StartCoroutine(master.GetComponent<mastercontroller_3>().PlayBossMusic());
                }

                break;
            case 11: //tu ryj tomasza, start 1 lvlva

                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Poruszaj się używając strzałek, skok to 'SPACJA'. Możesz również skoczyć podwójnie. Zbieraj swoje ulubione przedmioty i uważaj na przepaście!."));
                whichText = 0;
                masterController.GetComponent<mastercontroller_1>().PlayBackGroundMusic();
                break;
            case 21://cutscenka przed 1 levelem, drugi stopien
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ja muszę go poszukać, jak to sie mowi. No to ja teraz psznie zjem śniadanie boże i idę, może on u Mexycano jest."));
                whichText = 22;

                break;

            case 22: //special case to end cutscene at level 1 start
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("  "));
                playerScript.enabled = true;

                dialogueUI.SetActive(false);
                mainUI.SetActive(true);
                player.GetComponent<Animator>().enabled = true;

                anim1 = majorPokojBG.GetComponent<Animator>();
                anim1.SetInteger("In1Out2", 2); //for fading
                Invoke("StartPlayingLevel1", 3);
                break;

            /////////////START 2 LEVELA/////////////////mexyk
            case 23:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("No dzień dobry ugułem, ja się pytam gdzie jest ksiek bo on, ja podatki płacę, a jego nie ma nigdzie.. ooo że ja pasozyt??"));
                whichText = 24;
                break;
            case 24:
                NameChange("Czarny");
                PortraitChange(portretMex);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ja go nie widział. Ale! Ja! Dziś rano byłem przy torach i dziwne rzeczy słuchaj się działy! Ja nie wiem, może to po moczu ale wszędzie wokół były szproty w oleju i pomidorkach tam!!"));
                whichText = 25;
                break;
            case 25:
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("A! Major! Co ty robisz bo ludzie pisali mi że ty na ulgowych jezdzisz?!"));
                whichText = 26;
                break;
            case 26:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("No śmiechu warte, ja jestem jak to się mówi uczciwy i ludzie mnie chwalą. I ugułem to idę zobaczyć tam pod tory może jest tam ksiek naturze na loni.."));
                whichText = 27;
                break;
            case 27:
                NameChange("Czarny");
                PortraitChange(portretMex);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Major, człowieku przecież ty nie zginasz kolan, nigdy nie dojdziesz tam na czas! Ja mam inny pomysl, słuchaj:..."));
                whichText = 28;
                break;
            case 28:
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Kiedyś mi matka  dała szlaban na wychodzenie z domu, tak miesiąc temu. I tak mi się chciało kurde pić, że musiałem jakoś uciec, to zajebałem jej filiżankę i zrobiłem podkop w piwnicy..."));
                whichText = 29;
                break;
            case 29:
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Aż pod same tory się dokopałem i potem tym tunelem chodziłem na żuberka w ukryciu do mario. Chodź Major, pokaże ci wejście i idź nim, będzie szybciej!!"));
                whichText = 30;
                break;
            case 30:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("no dziękuję bardzo ugułem, ja głupoty nie gadam jak to się mówi i idę szukać mojego przyjaciela bożego"));
                whichText = 31;
                break;
            case 31:
                NameChange("Czarny");
                PortraitChange(portretMex);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Narazie, narazie, krzyżyk na drogę"));
                whichText = 33; //od razu na 33, niewazne czemu
                break;

            case 33:

                lvl2_startingCutscenePanel.GetComponent<Image>().enabled = false;
                player.GetComponent<Animator>().enabled = true;
                lvl2_startingCutscenePanel.GetComponent<cutscene_level2>().WalkLadder(); //oddaj kontrole cutscene controllerowi
                dialogueUI.SetActive(false);

                break;
            /////////////////////////////////////////////////////////////////MARIO
            case 34:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("ooo ten mario z.. krzków."));
                whichText = 35;
                break;
            case 35:
                NameChange("Mario");
                PortraitChange(portretMario);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("No Major. Moi koledzy byli i wszystko wiedzą. Ty za 14 latke siedzialeś, za gwałt!."));
                whichText = 36;
                break;
            case 36:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("jaki ty kurwa mqdry, ja nikogo nie zgwałcił."));
                whichText = 37;
                break;
            case 37:
                NameChange("Mario");
                PortraitChange(portretMario);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ja już nie mam słów, przez ciebie zostałem bez krzaku nad głową cały czas policja chodzi.. i jeszcze mi okulary ukradłeś!. Teraz się policzymy!!"));
                whichText = 38;
                break;
            case 38:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ooo jaki ty mądry. No to ugułem chodź lochudro!..."));
                whichText = 39;
                break;
            case 39:
                Invoke("Step40", .3f);
                break;
            case 41:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Ja nie laluś, kurwa!.. "));//teraz jejebak umiera
                whichText = 42;
                break;
            case 42:
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("  "));
                playerScript.enabled = true;
                gameCamera.GetComponent<CameraFollow>().enabled = true;
                playerScript.velocity = Vector3.zero;
                dialogueUI.SetActive(false);
                mainUI.SetActive(true);
                player.GetComponent<Animator>().enabled = true;
                canStartJebakFight = false;

                jejebak.GetComponent<jejebak>().DestroyGameObject();
                break;
            ///////////NERO///////////////////
            case 43:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("O! To przecież... ugułem piesek boży Nero! O cholllera... Nero to jest.. PRZYJACIEL Majora!!"));
                whichText = 44;
                break;
            case 44:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Przyjaciel Majora? Myślisz, że raz na miesiąc dasz mi jeść i jesteśmy przyjaciółmi??"));
                whichText = 45;
                break;
            case 45:
                NameChange("Major");
                PortraitChange(portretMaj);
                ; StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("O! Nero ja ci kości zanosił i całe te pamiętasz??"));
                whichText = 46;
                break;
            case 46:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Pieprzę Twoje kości, ćpunie suchy! Wiesz jak to jest siedzieć samemu miesiącami w tym obrzydliwym, śmierdzącym miejscu jakim jest wasz pożal się Boże belweder??"));
                whichText = 47;
                break;
            case 47:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Być na krótkim łańcuchu bez jedzenia i picia nawet w zimie?! Szkoda, ze zamiast tego basenu nie odgryzłem Ci fiuta... albo mózgu.. Chociaż u ciebie to jedno i to samo i tak!!)"));
                whichText = 48;
                break;
            case 48:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("oooo! a seselson ile razy ja ci dawał? "));
                whichText = 49;
                break;
            case 49:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("No tyle aż mi kości było widać, ciągle tylko głodny byłem! I wiesz co ci jeszcze powiem? Że w końcu jestem wolny i mam okazję ci dokopać, strusiu!!"));
                whichText = 50;
                break;
            case 50:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Za moje cierpienia odgryzę ci tę twoją suchą dupę!!"));
                whichText = 51;
                break;
            case 51:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("o cholera.."));
                whichText = 52;
                break;
            case 52:
                dialogueUI.SetActive(false);
                mainUI.SetActive(true);
                player.GetComponent<Animator>().enabled = true;
                player.GetComponent<Player>().enabled = true;

                break;
            //////// koniec walki z nerem
            case 53:
                NameChange("Nero");
                PortraitChange(portretNero);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Aaaa! Tak łatwo nie pozwolę Ci wygrać szczurze!!"));
                whichText = 54;
                break;
            case 54:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("OOO KURWA! nero jest jadowity ja ogolem musze wypic nitro zeby przezyc.."));
                whichText = 55;
                break;
            case 55:
                NameChange("Major");
                PortraitChange(portretMaj);
                //ledwo zywy nero lezy 
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("o do takiego banku to jeszcze nie byłem nidgy.. o cholllera... ja po prostu pije rozpuszczalnikow ani zadnych...."));
                whichText = 56;
                break;
            case 56:
                dialogueUI.SetActive(false);          
                Cursor.visible = false;
                fadeIn.SetActive(true);               
                Invoke("LoadLevel4", 1.5f);
                break;


            ///////ORBIT
            case 60:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Witaj Majorze! Jak Ci się podoba na księżycu??"));
                whichText = 61;
                break;
            case 61:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("no po prostu ja mam działalnosx i żubra widziałem całe te tam wcześniej i to był... ogołem żuber spaniały cholllera..."));
                whichText = 62;
                break;
            case 62:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Majorze nitro, które wypiłeś juz przestaje działać, musisz wracać na Ziemie.."));
                whichText = 63;
                break;
            case 63:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("niee to ja nie chcę on mnie tam obliza jak to się mówi ogołem juz ja go szukać nie będę bo ja nie kego kobieta jestem!."));
                whichText = 64;
                break;
            case 64:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Majorze! Krzysztof to Twój przyjaciel!!"));
                whichText = 65;
                break;
            case 65:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("no jak on konfidend ile ludzi on sprzdał ugułem spaślak."));
                whichText = 66;
                break;
            case 66:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Przypomnij sobie dobre chwile... szproty w oleju i pomidorkach i czasy pokoju..."));
                whichText = 67;
                break;
            case 67:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Podczas Twojej wizyty tutaj widziałem, że w Starosielcach źle się dzieje. Krzysztof jest już w domu. Ale oprócz niego jest ktoś jeszcze..."));
                whichText = 68;
                break;
            case 68:
                NameChange("Orbit");
                PortraitChange(portretOrbit);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Majorze, musisz natychmiast wracać do domu! Szkolna 17 jest w ogromnym niebezpieczeństwie!!!"));
                whichText = 69;
                break;
            case 69:
                NameChange("Major");
                PortraitChange(portretMaj);
                StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("o cholllera.. no to ja ide!!"));
                whichText = 0;
                break;
            // start ksiezyca, zagrac ambient i jazda
            case 70:
                player.GetComponent<Player>().enabled = true;
                dialogueUI.SetActive(false);
                break;
            //start 5 levela
            case 71:
                player.GetComponent<Player>().enabled = true;
                dialogueUI.SetActive(false);
                mastercontroller5.PlayMusic();               
                break;
        }


    }
    void Step40()
    {
        NameChange("Profesor Tomasz");
        PortraitChange(portretTomasz);
        StartCoroutine(typewriter.GetComponent<typewriter_effect>().ShowText("Panie Majorze! Po lewej stronie jest kamera! Proszę ją wziąć i rzucić klikając 'F'."));
        whichText = 0;
    }
    void StartPlayingLevel1()
    {
        playerScript.enabled = true;
        Destroy(cutsceneCanvas1);
    }
    void DestroyCanvas()
    {
        Destroy(cutsceneCanvas1);
    }
    void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

}

