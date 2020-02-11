using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Animator player;
    public bool isOnTheGround;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            player.SetTrigger("Speed");

        if (Input.GetKeyUp(KeyCode.D))
            player.SetTrigger("Stop");
        
        if (Input.GetKeyDown(KeyCode.I))
            player.SetTrigger("Punch");

        if (Input.GetKeyDown(KeyCode.J))
            player.SetTrigger("KickR");

        if (Input.GetKeyDown(KeyCode.K))
            player.SetTrigger("KickL");

        if (Input.GetKeyDown(KeyCode.U))
            player.SetTrigger("Jab");

        if (Input.GetKeyDown(KeyCode.A))
            player.SetTrigger("WalkBack");

        if (Input.GetKeyUp(KeyCode.A))
            player.SetTrigger("Stop");

        if (Input.GetKeyDown(KeyCode.W))
            player.SetTrigger("Jump");

    }
}
