using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All entities (ships, bullets, powerups, etc) will be based off of this abstract class
public abstract class Entity : MonoBehaviour {

    public Rigidbody2D rigidBody;

    public float moveSpeed;
}
