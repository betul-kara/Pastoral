using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField]
    AudioSource audioSourceMusic;
    private void Start()
    {
        LoadPlayerPrefs();
        //masterSlider.value = 0.5f;
        //musicSlider.value = 0.5f; 

        masterSlider.onValueChanged.AddListener(delegate { MasterValue(); });
        musicSlider.onValueChanged.AddListener(delegate { MusicValue(); });
        sfxSlider.onValueChanged.AddListener(delegate { SoundEffectValue(); });

    }
    private void OnDestroy()
    {
        // Uygulama kapandığında veya senaryo değiştiğinde değerleri kaydet
        SavePlayerPrefs();
    }

    private void LoadPlayerPrefs()
    {
        // Kaydedilmiş değerleri yükle
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    private void SavePlayerPrefs()
    {
        // Değişiklikleri kaydet
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

        // PlayerPrefs.Save() kullanarak değişiklikleri disk üzerinde kalıcı hale getirebilirsiniz, ancak genellikle otomatik olarak kaydedilir.
        PlayerPrefs.Save();
    }
    public void MasterValue()
    {
        audioMixer.SetFloat("master", Mathf.Log10(masterSlider.value) * 20);
    }
    public void MusicValue()
    {
        audioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
    }
    public void SoundEffectValue()
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxSlider.value) * 20);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
