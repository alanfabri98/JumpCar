using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //Attaking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public AudioSource soundLaser;
    //Sates
    public float sigthRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public GameObject projectile;
    public Animator animator;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    private void Awake()
    {
        //player = GameObject.Find("MonsterCar").transform;
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, sigthRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        //animator.SetBool("move", shouldMove);

        
        animator.SetFloat("velX", 0);
        animator.SetFloat("velY", 1);
    }
   
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkDistance = transform.position - walkPoint;
        if (distanceToWalkDistance.magnitude < 1f)
            walkPointSet = true;

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }

    private void ChasePlayer()
    {
        walkPoint = player.position;
        agent.SetDestination(walkPoint);
        
        
    }
    private void AttackPlayer()
    {
        walkPoint = player.position;
        agent.SetDestination(walkPoint);

        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            //Attack code

            GameObject gameObject = (GameObject)Instantiate(projectile,new Vector3( transform.position.x+2f, transform.position.y+1f    , transform.position.z), transform.rotation);
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x+90, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            soundLaser.Play();
            Destroy(gameObject, 3);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }




}
