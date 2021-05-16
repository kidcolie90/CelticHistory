using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>


public class HealthPu : MonoBehaviour
{


    public int healthAmount;
    public bool isFullyRestored;
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
        if (other.tag=="Player")
        {
            Destroy(gameObject);

          // if (isFullyRestored)
            {
                HealthMan.instance.healthReset();  //setting health back to max if player collects full restore
            }
          //  else
           // {
                HealthMan.instance.healthPU(healthAmount);
           // }
        }

    }
}
