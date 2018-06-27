using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateNormal : IState {

    Player player;

    public PlayerStateNormal(Player player) { this.player = player; }

    public void Enter()
    {
        
    }

    public void Execute()
    {
        // Make Player face the mouse
        player.FaceMouse();

        // Move Player
        player.PlayerMove();

        // Fire bullets on mouse down
        if (Input.GetMouseButtonDown(0))
        {
            player.FireWeapon();
        }

        player.DrawReflectionLaser();
    }

    public void Exit()
    {
        
    }
}
