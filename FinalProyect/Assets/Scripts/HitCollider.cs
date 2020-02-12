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
            if (owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))
            {
                Debug.Log("Punch");
                if(somebody != null && somebody != owner)
                {
                    somebody.hurt(Damage);
                }
            }

        }
    }
}
