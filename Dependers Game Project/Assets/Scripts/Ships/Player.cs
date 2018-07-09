using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {

    public GameObject weapon;

    public LayerMask hitLayers;

    public LineRenderer tracer;

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

    // Test Draw
    public void DrawReflectionLaser()
    {
        RaycastHit2D hit;
        Vector3 rayDir = transform.up;
        Vector2 startPoint = (new Vector2(transform.position.x, transform.position.y));

        //Debug.DrawLine(transform.position, hit.point, Color.red, 0.1f, false);
        for (int i = 0; i < 10; i++)
        {

            hit = Physics2D.Raycast(startPoint, rayDir, 1000f, hitLayers);

            if (!hit.collider.tag.Equals("Boundary"))
            {
                tracer.positionCount = i + 2;
                tracer.SetPosition(i, startPoint);
                tracer.SetPosition(i + 1, hit.point);
                //Debug.DrawLine(startPoint, hit.point, Color.red, 0.01f, false);
                rayDir = Vector3.Reflect((hit.point - startPoint).normalized, hit.normal);
                startPoint = hit.point;
            }
            else if (hit.collider.tag.Equals("Boundary"))
            {
                tracer.positionCount = i + 2;
                tracer.SetPosition(i, startPoint);
                tracer.SetPosition(i + 1, hit.point);
                break;
                //Debug.DrawLine(startPoint, hit.point, Color.red, 0.01f, false);
            }
            else
            {
                Debug.Log("ELSE");
                break;
            }
        }
    }
}
