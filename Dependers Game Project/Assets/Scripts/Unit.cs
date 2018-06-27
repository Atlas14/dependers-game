using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The abstract class that all ship units will be based off of
public abstract class Unit : Entity {

    public string id;

    public float health;

    public StateMachine stateMachine = new StateMachine();

}
