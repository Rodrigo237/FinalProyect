using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCharacter : MonoBehaviour
{
    public GameObject pulgaSelection;
    public GameObject comandanteSelection;

   public  void SelectionPulga()
    {
        pulgaSelection.transform.tag = "Player";
    }

    public void SelectionCR()
    {
        comandanteSelection.transform.tag = "Player";
    }
}
