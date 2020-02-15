using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostGenerator : MonoBehaviour
{

    public GameObject boostObject;
   
    // Start is called before the first frame update
    private GameObject destroyObj;
    private void Start()
    {
     
        StartCoroutine("AgregarBoost");
    }
    private void Update()
    {
      
    }
    IEnumerator AgregarBoost()
    {
        
       
        yield return new WaitForSeconds(15f);
        destroyObj=  Instantiate(boostObject, new Vector3(-41.8f, 5.1f, -55.3f), Quaternion.Euler(0.69f, 126.64f, 63.33f));
        
    }
}
