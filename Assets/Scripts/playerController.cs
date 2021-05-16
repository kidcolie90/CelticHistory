using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// code references, learned from online game courses: https://www.udemy.com/course/unity3dplatformer
/// </summary>

public class playerController : MonoBehaviour
{

    public static playerController instance; //will always be this instance of the player on multiple levels

    //when moving and rotatin always multiply by time.delta time to keep things relative
    public float moveSpeed;
    public float jumpForce;
    private Vector3 moveAround;
    public float gravScale = 5f;
    public float rotateSpeed;

    public Animator anim;

    public CharacterController charController;

    private Camera camMain;

    public GameObject playerModel;

    //vars for player being hit back below

    public bool isHitting;
    public float hitLength = .5f;
    private float hitBackCounter;
    public Vector2 hitPower;
    public float timeToAttack = 1f;
    private float attackCounter;

    public GameObject[] playerPieces;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        camMain = Camera.main; //setting main camera during the start method
    }

    // Update is called once per frame
    void Update()
    { //move player1 method

       


        if (!isHitting) //wrapped all player movements in conditional if statment so player will not be able to move while being hit or knocked back
        {


            float yStore = moveAround.y; //only used in this loop to fix gravity and offset snapping in unity
                                         //  moveAround = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //entering input in unity and getting raw value (direction being pressed on horiziontal or vertical axis) o for jump
            moveAround = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")); //movement in direction that the camera is facing 
            moveAround.Normalize(); //keeps movement speed the same when traversing map in diaganels, this was double forward and back speed before normailse function applied
            moveAround = moveAround * moveSpeed;
            moveAround.y = yStore;


      
             /*   if (Input.GetKeyDown(KeyCode.E))
                {
                if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)

                transform.rotation = Quaternion.Euler(0f, camMain.transform.rotation.eulerAngles.y, 0f); //quaternion are what rotations are calculated in
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveAround.x, 0f, moveAround.z)); //look direction to move with mouse around x and y axises , 0 on z axis
                                                                                                               //  playerModel.transform.rotation = newRotation; //player can move in correct look direction for example pressing down player will now look towards camera
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

                anim.SetTrigger("Attack");


            }*/





            if (charController.isGrounded) // stops character from flying by limiting y axis movment 
            {
                moveAround.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    moveAround.y = jumpForce;
                }
            }

            moveAround.y += Physics.gravity.y * Time.deltaTime * gravScale; //adding gravity to character


                                                                            //  transform.position = transform.position + (moveAround * Time.deltaTime * moveSpeed); //get current transform position and add on move direction to make main player move
            charController.Move(moveAround * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) //if there is input on either axis leep character facing the same directiaon as the camera
            {
                transform.rotation = Quaternion.Euler(0f, camMain.transform.rotation.eulerAngles.y, 0f); //quaternion are what rotations are calculated in
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveAround.x, 0f, moveAround.z)); //look direction to move with mouse around x and y axises , 0 on z axis
                                                                                                               //  playerModel.transform.rotation = newRotation; //player can move in correct look direction for example pressing down player will now look towards camera
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime); //taking current rotation, going to a new rotation and defining speed, this makes it look more smooth than above commented out section

            }



        }

        if (isHitting)
        {


            float yStore = moveAround.y; //only used in this loop to fix gravity and offset snapping in unity

            moveAround = playerModel.transform.forward * -hitPower.x;

            moveAround.y = yStore;


            moveAround.y += Physics.gravity.y * Time.deltaTime * gravScale; //adding gravity to character

            charController.Move(moveAround * Time.deltaTime);


            hitBackCounter -= Time.deltaTime; // taking 


            if(hitBackCounter <= 0)
            {
                isHitting = false;
            }

        }
      //  Attack();

        anim.SetFloat("Speed", Mathf.Abs(moveAround.x) + Mathf.Abs(moveAround.z)); //keeping move values always postitive using mathf absolute(abs) for animator condition in unity
        anim.SetBool("Grounded", charController.isGrounded);

     

      

    
    }

 



   public void hitBack()
    {

        isHitting = true;

        hitBackCounter = hitLength;
        moveAround.y = hitPower.y;


    }


}
