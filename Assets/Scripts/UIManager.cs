using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>


public class UIManager : MonoBehaviour
{


    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Image DeathImage;
    public Image celtic;
    public float fadeSpeed = 2f;
    public bool fadeToBlack, fadeFromBlack;
    public bool celtFadeTo, celtFadeFrom;
    public Text healthText;


    public GameObject PauseScreen, optionsScreen;

    public Slider musicVolSlider; //for music vol slider in options

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fadeToBlack)
        {

            DeathImage.color = new Color(DeathImage.color.r, DeathImage.color.g, DeathImage.color.b, Mathf.MoveTowards(DeathImage.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (DeathImage.color.a == 1f)
            {
                fadeToBlack = false;

            }

        
        }

        if (fadeFromBlack)
        {
            DeathImage.color = new Color(DeathImage.color.r, DeathImage.color.g, DeathImage.color.b, Mathf.MoveTowards(DeathImage.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (DeathImage.color.a == 0f)
            {
                fadeFromBlack = false;

            }


        }
        if (celtFadeTo)
        {

            celtic.color = new Color(celtic.color.r, celtic.color.g, celtic.color.b, Mathf.MoveTowards(celtic.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (celtic.color.a == 1f)
            {
                celtFadeTo = false;

            }


        }

        if (celtFadeFrom)
        {
            celtic.color = new Color(celtic.color.r, celtic.color.g, celtic.color.b, Mathf.MoveTowards(celtic.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (celtic.color.a == 0f)
            {
                celtFadeTo = false;

            }


        }
    }

    public void Resume()
    {


        GameManager.instance.PauseUnpause();



    }

    public void Options()
    {
        optionsScreen.SetActive(true);
    }


    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void MainMenu()
    {

    }


    public void setMusic()
    {

        AudioManager.instance.setMusicVol();


    }



}
