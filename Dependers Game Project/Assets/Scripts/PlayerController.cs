using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Player player;

    private void Start()
    {
        // Set player state machine
        player.stateMachine.ChangeState(new PlayerStateNormal(player));
    }

    // Update is called once per frame
    void Update () {
        // Run stateMachine update function
        player.stateMachine.Update();
    }
}
