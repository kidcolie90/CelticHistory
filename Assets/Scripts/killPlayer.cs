using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>


public class killPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //unity method to check if a player has entered a certain area in our case this is the edge of the map
    {
        if(other.tag == "Player")
        {
            GameManager.instance.Respawn();
        }
    }
}
