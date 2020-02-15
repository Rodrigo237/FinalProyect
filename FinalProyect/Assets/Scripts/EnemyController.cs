﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    private Rigidbody rbEnemy;
    public int lifeEnemy;
    public int currentHealth;
    public bool life = true;
    private float randomSetTime;
    private float randomHit;
    public float jumpEnemy;
    public Material materialHologram;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = lifeEnemy;
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
       
        enemyAnimator.SetTrigger("Speed");

        if (enemyAgent.remainingDistance <= 7f && enemyAgent.hasPath)
        {
            enemyAnimator.SetTrigger("Stop");
            randomHit = Random.Range(0,4);
            switch (randomHit){
                case 0:
            enemyAnimator.SetTrigger("Punch");
                    break;
                        case 1:
                    enemyAnimator.SetTrigger("Jab");
                    break;
                case 2:
                    enemyAnimator.SetTrigger("KickR");
                    break;
                case 3:
                    enemyAnimator.SetTrigger("KickL");
                    break;
                case 4:
                    enemyAnimator.SetTrigger("Jump");
                    rbEnemy.AddForce(Vector3.up * jumpEnemy, ForceMode.Impulse);
                    break;
            }
        }
        else
            enemyAnimator.SetTrigger("Speed");

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Hit")
        {
            currentHealth--;
            LifeBar.instanceLife.Damage();
            GetComponentInChildren<SkinnedMeshRenderer>().material = materialHologram;

        }
        Dead();
    }

    private void Dead()
    {
        if (LifeBar.instanceLife.LifeBarImageDanger.fillAmount == 0 && DataLoader.instance.currentEnemy.livesEnemy > 0)
        {
            
            enemyAnimator.SetTrigger("Dying");
            lifeEnemy--;
            DataLoader.instance.currentEnemy.livesEnemy--;
            DataLoader.instance.currentPlayer.victories++;
            DataLoader.instance.currentPlayer.Round += 1;
            DataLoader.instance.WriteData();
            DataLoader.instance.WriteDataEnemy();
            SceneManager.LoadScene(1);
        }
        if (DataLoader.instance.currentEnemy.livesEnemy == 0 )
        {
            DataLoader.instance.currentEnemy.livesEnemy = 2;
            DataLoader.instance.WriteDataEnemy();
            DataLoader.instance.currentPlayer.lives = 2;
            DataLoader.instance.currentPlayer.Round = 1;
            DataLoader.instance.WriteData();
            SceneManager.LoadScene(0);

        }
    }
}
