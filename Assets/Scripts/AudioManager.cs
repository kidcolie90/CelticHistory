using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update


        public static AudioManager instance;


    public AudioSource[] music;
    public int LevelMusic;
    private int MusicNow;
    public AudioMixerGroup musicMixer;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        PlayMusic(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MusicNow++;
            PlayMusic(MusicNow);

        }
    }

    public void PlayMusic(int musicToPlay)
    {

        for (int i =0; i< music.Length; i++) // for loop to stop current music playing and allow next trac to play 

        {
            music[i].Stop();
        }

        music[musicToPlay].Play();

    }

    public void setMusicVol()
    {
        musicMixer.audioMixer.SetFloat("MusicParam", UIManager.instance.musicVolSlider.value); //volume control for options menu
    }
}
