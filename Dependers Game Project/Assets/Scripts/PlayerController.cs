using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;         // Player movement speed

    public Rigidbody2D body;       // Player's Ridgidbody

    // Use this for initialization
    void Start()
    {
        // Get and store a reference to player ridgidbody
        body = GetComponent<Rigidbody2D>();
    }

    // Called per frame - use for non-physics calculations
    private void Update()
    {
        // Face player to mouse
        faceMouse();
    }

    // Physics update called before physics calculations per frame
    void FixedUpdate()
    {
        // Move player
        playerMove();
    }

    // Function to move player on keyboard input
    void playerMove()
    {
        // Set axis input to variables
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        // Add movement to player
        //body.AddForce(movement * moveSpeed);
        body.velocity = new Vector2(xMove * moveSpeed, yMove * moveSpeed);
    }

    // Function to have the player face the mouse
    void faceMouse()
    {
        // Get Mouse Position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Direction to face
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = dir;
    }
}
