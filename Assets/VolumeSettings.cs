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
        if (PlayerPrefs.HasKey("BGMVolume"))
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
         myMixer.SetFloat("BGMVolume", Mathf.Log10(volum)*20);
         PlayerPrefs.SetFloat("BGMVolume",volum);
    }
    public void SetSFXVolum()
    {
        float volum = SFXSlider.value;
        myMixer.SetFloat("SFXVolume", Mathf.Log10(volum) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volum);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolum();
    }
}
