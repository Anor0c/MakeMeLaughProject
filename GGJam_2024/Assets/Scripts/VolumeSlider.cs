using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mix;
    public void MainVolume(float volume)
    {
        mix.SetFloat("MasterVolume", volume); 
    }
    public void MusicVolume(float volume)
    {
        mix.SetFloat("MusicVolume", volume);
    }
    public void SFXVolume(float volume)
    {
        mix.SetFloat("SFXVolume", volume);
    }
}
