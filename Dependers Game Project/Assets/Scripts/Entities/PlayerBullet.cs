using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Entity {

    public Transform player;

    public float damage;

    public void Start()
    {
        // Move the bullet in the direction it's facing on instantiation
        rigidBody.velocity = gameObject.transform.up * moveSpeed;
    }

    public void OnTriggerExit()
    {
        
    }
}
