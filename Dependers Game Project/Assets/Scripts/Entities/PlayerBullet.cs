using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Entity {

    public GameObject player;

    public float damage;

    public LayerMask hitLayers;

    public void Start()
    {
        
    }

    public void Update()
    {
        // Perform bullet reflection
        Reflect();

        // Keep the bullet moving in the direction it's facing
        rigidBody.velocity = gameObject.transform.up * moveSpeed;
    }

    // Function for bouncing bullets off of enemies
    public void Reflect()
    {
        // Fire off a ray in the direction the bullet is facing to see if it bounces off anything
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up, 0.5f, hitLayers);

        // If the ray hits something with a collider (that is not the player, the background, or itself), reflect the bullet at the angle of reflection
        if (rayHit.collider != null)
        {
            Vector3 rayDir = Vector3.Reflect((rayHit.point - (new Vector2(transform.position.x, transform.position.y))).normalized, rayHit.normal);

            float angle = Mathf.Atan2(-rayDir.x, rayDir.y) * Mathf.Rad2Deg;
            var targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = targetRot;
        }
    }
}
