using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    // Get the slime element from Unity
    public Rigidbody2D myRigidbody;

    // Connect to the logic script
    public LogicManager logic;
    public float velocityMultiplier;
    public float height = 10;
    public bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (running)
        {
            // Check which direction the user has inputted, if any. 
            float horizontalInput = Input.GetAxis("Horizontal");

            // Create a vector mirroring the user input
            Vector2 movement = new Vector2(horizontalInput, 0f);

            // Apply the new vector to create movement. The velocityMultiplier
            // adjusts the rate at which the slime moves, and the y value remains the same. 
            myRigidbody.velocity = new Vector2(movement.x * velocityMultiplier, myRigidbody.velocity.y);
        }
        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && running)
        {
            // Create a new velocity up for when the user jumps, x remains the same. 
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, height);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the user hits any wall, the Dead() function is called, increasing the
        // death counter and resetting the slime back at the start. 
        if (collision.gameObject.layer == LayerMask.NameToLayer("Maze"))
        {
            logic.Dead();
        }
            
    }

    // For when the Slime crosses the finish line.
    public void StopRunning()
    {
        running = false;
    }
}
