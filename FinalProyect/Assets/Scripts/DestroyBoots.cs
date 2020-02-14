using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoots : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
