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
    public AudioClip[] sfx;
    private AudioSource playerSource;
    public int life;
    void Start()
    {
        player = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            player.SetTrigger("Speed");

        if (Input.GetKeyUp(KeyCode.D))
            player.SetTrigger("Stop");

        if (Input.GetKeyDown(KeyCode.I))
        {
            player.SetTrigger("Punch");
            playerSource.PlayOneShot(sfx[0]);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            player.SetTrigger("KickR");
            playerSource.PlayOneShot(sfx[1]);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            player.SetTrigger("KickL");
            playerSource.PlayOneShot(sfx[1]);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            player.SetTrigger("Jab");
            playerSource.PlayOneShot(sfx[0]);
        }

        if (Input.GetKeyDown(KeyCode.A))
            player.SetTrigger("WalkBack");

        if (Input.GetKeyUp(KeyCode.A))
            player.SetTrigger("Stop");

        if (Input.GetKeyDown(KeyCode.W))
            player.SetTrigger("Jump");
            
        
    }

    public void hurt(float damage)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            playerSource.PlayOneShot(sfx[2]);
        }
    }
}
