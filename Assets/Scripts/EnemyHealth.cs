using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>

public class EnemyHealth : MonoBehaviour
{
    public Animator anim;

    private int health;
    public int maxHealth =1;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pain()
    {

        health--;

        if (health <= 0)
        {
            anim.SetBool("IsDead",true);


            Destroy(gameObject);
        }

    }
}
