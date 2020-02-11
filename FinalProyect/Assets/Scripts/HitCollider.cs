using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public string punchName;
    public float Damage;
    public PlayerController owner;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController somebody = other.gameObject.GetComponent<PlayerController>();

        if(somebody != null && somebody != owner)
        {
            Debug.Log("Punch");
        }
    }
}
