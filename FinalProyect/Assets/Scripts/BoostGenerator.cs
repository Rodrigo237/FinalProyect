using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostGenerator : MonoBehaviour
{

    public GameObject boostObject;
    // Start is called before the first frame update

    private void Start()
    {
        boostObject.SetActive(false);
    }
    private void Update()
    {
        Invoke("AgregarBoost",15f);
    }
    void AgregarBoost()
    {
        Instantiate(boostObject, new Vector3(-41.8f,5.1f,-55.3f),Quaternion.Euler(0.69f,126.64f,63.33f));
        boostObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
