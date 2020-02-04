using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum UIState { START_MENU,MAIN_MENU, OPTIONS, CREDITS };
public class UIManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public GameObject controlsPanel;
    public GameObject selectionPanel;
    private UIState currentState;
    void Start()
    {
        currentState = UIState.START_MENU;
        CleanUI();
        startMenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CleanUI()
    {
        startMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        selectionPanel.SetActive(false);
    }

    public void StartGame() {
        startMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        selectionPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Versus()
    {
        selectionPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Options()
    {

        optionsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void Credits()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Controls()
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void ReturnOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void ReturnCredits()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ReturnControls()
    {
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false); 
    }
}
