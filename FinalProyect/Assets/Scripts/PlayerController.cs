using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float jumpForce;
    public Animator player;
    private Rigidbody RBplayer; 
    public bool isOnTheGround;
    // Start is called before the first frame update
    public AudioClip[] sfx;
    private AudioSource playerSource;
    public GameObject badBoost;
    private bool isActiveBoost;
    public int life;
    private bool ActiveBate;
    public int currentHealth;
    void Start()
    {
        player = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
        RBplayer = GetComponent<Rigidbody>();
        badBoost.SetActive(false);
        isActiveBoost = false;
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

        if (Input.GetKeyDown(KeyCode.W) && isOnTheGround)
        {
            player.SetTrigger("Jump");
            RBplayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.O) && isActiveBoost)
        {
            player.SetTrigger("Boost");
            playerSource.PlayOneShot(sfx[0]);
        }
        
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            playerSource.PlayOneShot(sfx[2]);
        }

        if (collision.gameObject.tag == "Ground")
        {
            isOnTheGround = true;
        } 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (other.tag == "Bate")
            {
                badBoost.SetActive(true);
                isActiveBoost = true;
            }
        }
       if (other.tag == "Hit")
            {
                currentHealth--;
                LifeBarPlayer.instanceLife.Damage();
            }
        
    }

    private void DeadPlayer()
    {
        if (LifeBarPlayer.instanceLife.LifeBarImageDanger.fillAmount == 0)
            player.SetTrigger("Dying");
    }
}
