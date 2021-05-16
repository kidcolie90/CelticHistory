using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>


public class HealthMan : MonoBehaviour
{

    public static HealthMan instance;

    public int healthNow, MaxHealth;

    public float invincibleDuration = 2f;
    private float invinibleCounter;

    private void Awake()
    {
        instance = this;
        }
    // Start is called before the first frame update
    void Start()
    {
        healthReset(); //starting level health is set to max health 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invinibleCounter > 0)

        { 
            invinibleCounter -= Time.deltaTime;
     

            for (int i = 0; i < playerController.instance.playerPieces.Length; i++)
            {

                if (Mathf.Floor(invinibleCounter * 5f) % 2 == 0)
                {
                    playerController.instance.playerPieces[i].SetActive(true);
                }

                else
                {
                    playerController.instance.playerPieces[i].SetActive(false);


                    

                }
                

            }


        }


    }
    
    public void Damage()
    {

        if (invinibleCounter <= 0)
        {

            healthNow--;


            if (healthNow <= 0)
            {

                healthNow = 0;

                GameManager.instance.Respawn();
            }
            else
            {
                playerController.instance.hitBack();




            }

            updateUI();
        } 
    }


    public void healthReset()
    {

        healthNow = MaxHealth;

        updateUI();

    }

    public void healthPU(int healthAmount)
    {
        healthNow += healthAmount; //current health plus amount of health added after health pick up

        if(healthNow > MaxHealth) // if statement stops health from going above maximum health
        {
            healthNow = MaxHealth;

            updateUI();
        }
    }


    public void updateUI()
    {

        UIManager.instance.healthText.text = healthNow.ToString();
    }
        

}
