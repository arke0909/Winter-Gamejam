using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolum();
            SetSFXVolum();
        }
        
    }
    public void SetMusicVolum()
    {
         float volum = musicSlider.value;
         myMixer.SetFloat("music",Mathf.Log10(volum)*20);
         PlayerPrefs.SetFloat("musicVolume",volum);
    }
    public void SetSFXVolum()
    {
        float volum = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volum) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volum);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolum();
    }
}
