using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musics, effects;

    public AudioSource backgroundMusic, hit, enemyDeath, blood, boneRing, backgroundMusicBoss, levelUp, fireBall;

    public static AudioManager instance;

    [Range(-80,10)]
    public float masterMusicsVol, masterEffectsVol;
    public Slider musicSlider, effectSlider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    private void Update()
    {
        MasterVolume();
        EffectsVolume();
    }

    private void Start()
    {
        PlayAudio(backgroundMusic);
        musicSlider.value = masterMusicsVol;
        effectSlider.value = masterEffectsVol;

        musicSlider.minValue = -80f;
        musicSlider.maxValue = 10f;

        effectSlider.minValue = -80f;
        effectSlider.maxValue = 10f;
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void StopAudio(AudioSource audio)
    {
        audio.Stop();
    }

    public void MasterVolume()
    {
        musics.SetFloat("masterMusicVolume", musicSlider.value);
    }

    public void EffectsVolume()
    {
        effects.SetFloat("masterEffectsVolume", effectSlider.value);
    }
}
