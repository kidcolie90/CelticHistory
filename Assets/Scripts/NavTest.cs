using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public NavMeshAgent agent;
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
