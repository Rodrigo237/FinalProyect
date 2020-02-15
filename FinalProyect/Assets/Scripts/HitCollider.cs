using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public string punchName;
    public float Damage;
    

     

    private void OnTriggerEnter(Collider other)
    {
        PlayerController somebody = other.gameObject.GetComponent<PlayerController>();     
    }
}
