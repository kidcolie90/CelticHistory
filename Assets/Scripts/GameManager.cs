using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private Vector3 respawnPoint;

    //any game manager script in whole game is set to this static instance
    private void Awake() //awake function used to set instances as soon as game starts
    {
        instance = this; 
    }

    



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // sets cursor to invisable during game play
        Cursor.lockState = CursorLockMode.Locked; //locks cursor to centre  of screen being invisible 
        
        
        respawnPoint = playerController.instance.transform.position; //player respawn point
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void Respawn() //non unity native function to respawn player
    {
        StartCoroutine(RespawnCo());
    }


    public IEnumerator RespawnCo() //respawn co routine, actions to be taken during respawnp -
    {

        UIManager.instance.fadeToBlack = true;

        UIManager.instance.celtFadeTo = true;

        playerController.instance.gameObject.SetActive(false); //setting player to disabled

      //  CamController.instance.cineBrain.enabled = false;//setting camera to disabled 

        yield return new WaitForSeconds(2f);  //wait three seconds before sending player back to spawn point

        HealthMan.instance.healthReset(); //resetting health for respawn

        UIManager.instance.fadeFromBlack = true;
        UIManager.instance.celtFadeFrom = true;
        playerController.instance.transform.position = respawnPoint;

       // CamController.instance.cineBrain.enabled = true; // renable camera

        playerController.instance.gameObject.SetActive(true); //renable player at original spawn point captured above


    }

    public void setSpawnPoint(Vector3 newSpawn)
    {
        respawnPoint = newSpawn;



    }

    public void PauseUnpause()
    {
        if (UIManager.instance.PauseScreen.activeInHierarchy)
        {

            UIManager.instance.PauseScreen.SetActive(false);

            Time.timeScale = 1f; // sets time to regular passing of time for unpause

            Cursor.visible = false; // sets cursor to invisable during game play
            Cursor.lockState = CursorLockMode.Locked; //locks cursor to centre  of screen being invisible 
        }
        else
        {

            UIManager.instance.PauseScreen.SetActive(true);
            UIManager.instance.CloseOptions(); // close options screen if pause screen is active 
            Time.timeScale = 0f; //sets passing of time to 0 in game for pausing
            Cursor.visible = true; // sets cursor to visible during pause
            Cursor.lockState = CursorLockMode.None; //allows cursor to move during pause
        }
    }
}
