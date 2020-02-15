using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class UIManagerInGame : MonoBehaviour
{
    public GameObject HUDPanel;
    public GameObject pausePanel;
    //HUD Elements
    public TextMeshProUGUI victoriesText;
    public TextMeshProUGUI defeatsText;
    public TextMeshProUGUI roundText;
    //Pause Elements
    public Slider musicSlider;
    public Slider sfxSlider;

    //Audio Elements
    public AudioMixer mainMixer;
    private float musicVolume;
    private float sfxVolume;
    // Start is called before the first frame update
    void Start()
    {
        CleanUI();
        HUDPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        victoriesText.text = " Wins x" + DataLoader.instance.currentPlayer.victories;
        defeatsText.text = "Losses x" + DataLoader.instance.currentPlayer.defeats;
        roundText.text = "Round  " + DataLoader.instance.currentPlayer.Round;
    }

    private void CleanUI()
    {
        HUDPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void ShowPause()
    {
        CleanUI();
        pausePanel.SetActive(true);
        mainMixer.GetFloat("musicVolume", out musicVolume);
        musicSlider.value = musicVolume;
        DataLoader.instance.currentPlayer.musicVolume = musicSlider.value;
        mainMixer.GetFloat("sfxVolume", out sfxVolume);
        sfxSlider.value = sfxVolume;
        DataLoader.instance.currentPlayer.sfxVolume = sfxSlider.value;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        CleanUI();
        HUDPanel.SetActive(true);
    }

    public void Salir()
    {
        Debug.Log("Salir");
        DataLoader.instance.WriteData();
        DataLoader.instance.WriteDataEnemy();
        Application.Quit();
    }

    public void SetMusic(float volume)
    {
        mainMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFX(float sfx)
    {
        mainMixer.SetFloat("sfxVolume", sfx);
    }
}
