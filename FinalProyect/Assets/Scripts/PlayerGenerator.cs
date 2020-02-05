using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    SelectionCharacter playerCharacter = new SelectionCharacter();
    public GameObject playerSelectedME;
    public GameObject playerSelectedCR;
    // Start is called before the first frame update
    void Start()
    {
        
            Instantiate(playerSelectedME, transform.position, Quaternion.identity); 
            Instantiate(playerSelectedCR, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
