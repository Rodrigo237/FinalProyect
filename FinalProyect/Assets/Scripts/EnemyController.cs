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
        Debug.Log("Distance to player: " + enemyAgent.remainingDistance);
        enemyAnimator.SetTrigger("Speed");

        if (enemyAgent.remainingDistance <= 7f && enemyAgent.hasPath)
        {
            enemyAnimator.SetTrigger("Stop");
            enemyAnimator.SetTrigger("Punch");
        }
        else
            enemyAnimator.SetTrigger("Speed");
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Hit")
        {
            currentHealth--;
            lifebar.Damage();
        }
    }

    
}
