using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject checkOn, checkOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player")
        {
            GameManager.instance.setSpawnPoint(transform.position); //sending transform position of this check point to game manager to assign new respawn position

            Checkpoint[] allChecks = FindObjectsOfType<Checkpoint>(); //find all checkpoints in scene and putting them into an array

            for (int i =0; i < allChecks.Length;i++) //looping through all checkpoints 
            {
                allChecks[i].checkOff.SetActive(true);
                allChecks[i].checkOn.SetActive(false);
            }

            checkOff.SetActive(false);
            checkOn.SetActive(true);
        
        }
    }
}
