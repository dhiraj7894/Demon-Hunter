using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonController : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]private NavMeshAgent agent;
    private Animator demonAnime;
    private bool isDead = false;
    
    public LayerMask WhatIsGround, WhatIsPlayer;
    public float CurrentHealth;
    public float maxHealth = 75;
    public float WalkPointRange;
    public float timeBetweenAttack;
    public float sightRange, attackRange;

    [SerializeField]private bool walkPointSet;
    [SerializeField]private bool alreadyAttacked;
    [SerializeField]private bool isPlayerInSightRange, isPlayerInAttackRange;
    [SerializeField]private Vector3 walkPoint;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        demonAnime = this.GetComponent<Animator>();
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        if (isDead)
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        if (!isDead)
        {
            if (!isPlayerInAttackRange && !isPlayerInSightRange) Petrolling();
            if (isPlayerInSightRange && !isPlayerInAttackRange) ChasePlayer();
            if (isPlayerInAttackRange && isPlayerInSightRange) AttackPlayer();
        }
    }

    private void Petrolling()
    {
        if (!walkPointSet) searchForPoint();

        if (walkPointSet)
        {
            this.agent.SetDestination(walkPoint);
            demonAnime.SetBool("run",true);
            transform.LookAt(walkPoint);
        }

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void searchForPoint()
    {
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up,2f,WhatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(Player.transform.position);
        transform.LookAt(Player.transform.position);
        demonAnime.SetBool("run", true);
    }
    private void AttackPlayer()
    {
        demonAnime.SetBool("run", false);
        agent.SetDestination(transform.position);

        transform.LookAt(Player.transform.position);

        if (!alreadyAttacked)
        {
            //Attack code here
            //demonAnime.Play("Zombie Attack");
            demonAnime.SetTrigger("attack");
            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttack);
        }
    }
    private void resetAttack()
    {
        alreadyAttacked = false;
    }
    public void takeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            isDead = true;
            demonAnime.SetBool("dead", true);
        }
    }
    public void Die()
    { 
        Destroy(this.gameObject, 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
