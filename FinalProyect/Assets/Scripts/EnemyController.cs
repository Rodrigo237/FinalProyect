using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    public int lifeEnemy;
    public int currentHealth;
    public bool life = true;
    private float Random;
    private float randomSetTime;
    private float randomHit;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = lifeEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
       
        enemyAnimator.SetTrigger("Speed");

        if (enemyAgent.remainingDistance <= 7f && enemyAgent.hasPath)
        {
            enemyAnimator.SetTrigger("Stop");
            randomHit = Random.Range(0, 3);
            switch (randomHit){
                case 0:
            enemyAnimator.SetTrigger("Punch");
                    break;
                        case 1:
                    enemyAnimator.SetTrigger("Jab");
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
            Dead();
        }
    }

    private void Dead()
    {
        if (LifeBar.instanceLife.LifeBarImageDanger.fillAmount == 0)
            enemyAnimator.SetTrigger("Dying");
    }
}
