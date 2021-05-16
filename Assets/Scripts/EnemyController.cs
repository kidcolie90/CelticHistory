using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>


public class EnemyController : MonoBehaviour
{


    public Transform[] patrolAreas; //area of transform co ordinates for enemy to patrol
    public int currentPatrolArea;
    public NavMeshAgent agent;
    public Animator anim;


    public enum AIState         // object that can hold multiple states and asign number to them much like array - used to control enemy patrol in this case

    {
        isIdle, isPatroling, isChasing, isAttacking 

    };



    public AIState currentState;


    public float waitAtPoint;
    private float waitCounter;

    public float chaseDistance;

    public float attackRange = 1f; //how close before attacking player

    public float timeToAttack = 2f;
    private float attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {


        float distanceToP1 = Vector3.Distance(transform.position, playerController.instance.transform.position); //tells us how far away the player is, will be used for enemy chase


        switch (currentState) //switch statment outlining all of the AI states
        {

            case AIState.isIdle: //idle state
                anim.SetBool("IsMoving", false);
                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.isPatroling;
                    agent.SetDestination(patrolAreas[currentPatrolArea].position); //setting destination (Telling agent what new destination is)
                }


                if (distanceToP1 <= chaseDistance)
                {
                    currentState = AIState.isChasing;
                    anim.SetBool("IsMoving", true); //telling the animator to enter the is moving animation when chasing, the banshees arms bob 

                }


                break;

            case AIState.isPatroling: // patrol state

        


                if (agent.remainingDistance <= .2f) //if enemy is less than than 0.2f away from patrol point move to next one
                {
                    currentPatrolArea++;
                    if (currentPatrolArea >= patrolAreas.Length) // if the current patrol area now exceed the amount of points in the array set it back to zero - this allows looping back to the start
                    {
                        currentPatrolArea = 0;
                    }
                    // agent.SetDestination(patrolAreas[currentPatrolArea].position);//

                    currentState = AIState.isIdle; // setting the current state to be idle
                    waitCounter = waitAtPoint; // resetting the wait counter


                }


                if (distanceToP1 <= chaseDistance)
                {
                    currentState = AIState.isChasing;

                }



                anim.SetBool("IsMoving", true);

                break;


            case AIState.isChasing:  // chasing state

                agent.SetDestination(playerController.instance.transform.position); // setting the ai agent position to be the transform position of the player causing a chase effect

                if (distanceToP1 <=attackRange)
                {
                    currentState = AIState.isAttacking;
                    anim.SetTrigger("Attack");
                    anim.SetBool("IsMoving", false); //stopping run annimation 


                    agent.velocity = Vector3.zero; // stopping AI from trying to do run or move animations while attacking
                    agent.isStopped = true;

                    attackCounter = timeToAttack;

                  
                }


                if (distanceToP1 > chaseDistance)
                {
                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint; 

                    agent.velocity = Vector3.zero; //setting the speed of agent to zero
                    agent.SetDestination(transform.position);
                }

                break;

            case AIState.isAttacking:

                transform.LookAt(playerController.instance.transform, Vector3.up); //unity method to point enemy at players transform position
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f); // using quaternion.eurler to set transform as vector tree because quaternion math is crazy, this is to keep enemy looking at players transform and falling over from trying to look players transform on x and y axis
                attackCounter -= Time.deltaTime; //if attack is finsihed and enemy is within range of player attack again

                if (attackCounter <=0)
                {
                    if (distanceToP1 < attackRange)
                    {
                        anim.SetTrigger("Attack");
                        attackCounter = timeToAttack; //resetting attack counter to start attack again 
                    }
                    else //allowing player to go back to patolling map after attacking 
                    {
                        currentState = AIState.isIdle;
                        waitCounter = waitAtPoint;
                        agent.isStopped = false; 
                    }
                }


                break;

        }
    } 

}
