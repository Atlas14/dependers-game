using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {

    public GameObject weapon;

	// Use this for initialization
	void Start () {

        // Set rigidbody
        rigidBody = GetComponent<Rigidbody2D>();

        // Set player state machine
        stateMachine.ChangeState(new PlayerStateNormal(this));
    }

    // Called per frame before physics calculations
    private void FixedUpdate()
    {
        
    }

    // Called per frame - use for non-physics calculations
    private void Update()
    {
        // Run stateMachine update function
        stateMachine.Update();

        // Fire bullets on mouse down
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    // Function to move player on keyboard input
    public void PlayerMove()
    {
        // Set axis input to variables
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        // Add movement to player
        rigidBody.velocity = new Vector2(xMove * moveSpeed, yMove * moveSpeed);
    }

    // Function to have the player face the mouse
    public void FaceMouse()
    {
        // Get Mouse Position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Direction to face
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = dir;
    }

    public void FireWeapon()
    {
        Instantiate(weapon, transform.position, Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z)));
    }
}
