using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Reloj : MonoBehaviour
{
    public float startTime = 90f;
    public TextMeshProUGUI ContadorText;
    public int timeToText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime >=0)
        startTime -= Time.deltaTime;
        timeToText = (int)startTime;
        ContadorText.text = timeToText.ToString();
    }
}
