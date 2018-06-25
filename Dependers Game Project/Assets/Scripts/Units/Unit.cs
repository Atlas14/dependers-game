using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The abstract class that all units will be based off of
public abstract class Unit : MonoBehaviour {

    public string id;

    public float health;
    public float moveSpeed;

    [HideInInspector]
    public Rigidbody2D rigidBody;

    public StateMachine stateMachine = new StateMachine();

}
