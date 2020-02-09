using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionCharacter : MonoBehaviour
{
    public GameObject pulgaSelection;
    public GameObject comandanteSelection;

   public  void SelectionPulga()
    {
        //DontDestroyOnLoad(this.gameObject);
        //this.getcomponent<>().enabled=; |
     //   pulgaSelection.transform.tag = "Player";
        SceneManager.LoadScene(1);
    }

    public void SelectionCR()
    {
    //    comandanteSelection.transform.tag = "Player";
        SceneManager.LoadScene(1);
    }
}
