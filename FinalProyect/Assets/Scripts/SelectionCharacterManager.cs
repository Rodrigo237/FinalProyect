using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionCharacterManager : MonoBehaviour
{
    public static bool pulgaSelection;
    public static bool comandanteSelection;
    public GameObject pulga;
    public GameObject comandante;

    private void Awake()
    {
        pulgaSelection = false;
        comandanteSelection = false;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public  void SelectionPulga()
    {
       
        pulgaSelection =  true;
        if (pulgaSelection == true)
        {
            pulga.transform.tag = "Player";
            pulga.GetComponent<PlayerController>().enabled = true;
            pulga.GetComponent<EnemyController>().enabled = false;
            comandante.transform.tag = "Enemy";
            comandante.GetComponent<PlayerController>().enabled = false;
            comandante.GetComponent<EnemyController>().enabled = true;
            SceneManager.LoadScene(1);
        }
    }

    public void SelectionCR()
    {

        comandanteSelection = true;
        if (comandanteSelection == true)
        {
            comandante.transform.tag = "Player";
            comandante.GetComponent<PlayerController>().enabled = true;
            comandante.GetComponent<EnemyController>().enabled = false;
            pulga.transform.tag = "Enemy";
            pulga.GetComponent<PlayerController>().enabled = false;
            pulga.GetComponent<EnemyController>().enabled = true;
            SceneManager.LoadScene(1);
        }
      
        
    }
}
