using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    [SerializeField] LayerMask ground_layers;
    [SerializeField] LayerMask world_layers;
    [SerializeField] float speed;
    [SerializeField] float jump_height;


    private float gravity = -50f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool grounded;
    private bool released_up_arrow;
    private int remaining_jumps;

    private int selected_character;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        released_up_arrow = false;
        remaining_jumps = 1;
        //selected_character = 1;
        selected_character = PlayerPrefs.GetInt("selected_character");
    }



    // Update is called once per frame

    void Update()
    {
        Vector3 bot_transform = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        if (transform.position.y < -5)
        {
            FindObjectOfType<Manager>().gameover();
        }


        float movement_x = 1f;
        float movement_z = 0.5f;

        grounded = Physics.CheckSphere(bot_transform, 0.1f, ground_layers, QueryTriggerInteraction.Ignore);


        //GROUNDED and JUMPING
        if (grounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            velocity.y += Mathf.Sqrt(jump_height * -1f * gravity);
        }
        
        //DOUBLE JUMP IMPLEMENTATION
        
        //in the air and is no longer pressing up
        if (!grounded && !(Input.GetKey(KeyCode.Space))) {
            released_up_arrow = true;
        }

        //in the air, pressed up again, is on the correct char, and has a jump remaining
        if (released_up_arrow && !grounded && remaining_jumps > 0 && selected_character == 0 && Input.GetKey(KeyCode.Space))
        {
            velocity.y = 0;
            velocity.y += Mathf.Sqrt(jump_height * -1f * gravity);
            remaining_jumps -= 1;
        }

        //clean up the released up arrow and jumps remaining
        if (grounded)
        {
            released_up_arrow = false;
            remaining_jumps = 1;
        }


        

        
        //DIFFERENT MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            if (selected_character != 1)
            {
                transform.forward = new Vector3(movement_x, 0, 0);
                //Making char move forwards in x direction
                controller.Move(new Vector3(movement_x, 0, 0) * speed * Time.deltaTime);

            }
            else
            {
                transform.forward = new Vector3(movement_x * 2, 0, 0);
                //Making char move forwards in x direction
                controller.Move(new Vector3(movement_x * 2, 0, 0) * speed * Time.deltaTime);
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.forward = new Vector3(-movement_x, 0, 0);
            //Making char move forwards in x direction
            controller.Move(new Vector3(-movement_x, 0, 0) * speed * Time.deltaTime);
        }

 


        //LEFT-RIGHT MOVEMENT
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            velocity.z = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.z = movement_z * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.z = -1 * movement_z * speed;
        }
        else
        {
            velocity.z = 0;
        }


        //Making char move w/ gravity
        controller.Move(velocity * Time.deltaTime);

        //Move forwards
    }
}
