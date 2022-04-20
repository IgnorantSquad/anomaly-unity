using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerLocomotionState : State
{
    public override Identity ID => State.Identity.PlayerLocomotion;

    private Vector3 moveDir = Vector3.zero;
    private float gravity = 0F;

    private Vector3 handlePos = new Vector3(5F, 0.5f, -10F);

    public override void OnEnter(CustomBehaviour target)
    {

    }

    public override void OnExit(CustomBehaviour target)
    {

    }

    public override void OnFixedUpdate(CustomBehaviour target)
    {
        var player = target as Player;
        var physicsData = player.actorPhysics.CurrentPhysicsData;

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        player.actorPhysics.Move(moveDir * Time.deltaTime * moveSpeed);
    }

    public override void OnUpdate(CustomBehaviour target)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical") * 0F;
        moveDir.x = h;

        var player = target as Player;
        var physicsData = player.actorPhysics.CurrentPhysicsData;

        //float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        //player.actorPhysics.Move(dir * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && player.actorPhysics.IsGrounded)
        {
            gravity = 5F;
            player.actorPhysics.AddForce(Vector3.up * physicsData.jumpPower.Default, ForceMode.Impulse);
        }

        //if (moveDir.x > 0F) handlePos = new Vector3(2.5f, 0.5f, -10F);
        //else if (moveDir.x < 0F) handlePos = new Vector3(-2.5f, 0.5f, -10F);
        if (Input.mousePosition.x > Screen.width * 0.65f) handlePos = new Vector3(2.5F, 0.5f, -10F);
        else if (Input.mousePosition.x < Screen.width * 0.35f) handlePos = new Vector3(-2.5F, 0.5f, -10F);
        //handlePos = moveDir.x > 0F ? new Vector3(5F, 0.5f, -10F) : moveDir.x < 0F ? new Vector3(-5F, 0.5f, -10F) : handlePos;

        player.actorCamera.SetCameraHandlePosition(handlePos);
        //player.actorCamera.SetCameraHandlePosition(new Vector3(5F * h, 0.5f, -10F));
    }

    public override void OnLateUpdate(CustomBehaviour target)
    {

    }
}
