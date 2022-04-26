using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerLocomotionState : State
{
    public override Identity ID => State.Identity.PlayerLocomotion;

    //private Vector3 moveDir = Vector3.zero;
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
        var physicsData = player.actorCharacter.CurrentPhysicsData;

        player.actorCharacter.CalculateGravity();

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, player.actorCharacter.GravityValue, 0F);
        Vector3 slideVector = player.actorCharacter.GetSlideVector(2F);

        if (Mathf.Abs(moveDir.x + slideVector.x) < Mathf.Abs(moveDir.x) && moveDir.y <= 0F)
        {
            moveDir.x = 0F;
        }

        moveDir += slideVector;

        //player.actorPhysics.Move(moveDir * Time.deltaTime * moveSpeed);
        player.actorCharacter.Move(moveDir);
    }

    public override void OnUpdate(CustomBehaviour target)
    {
        var player = target as Player;
        var physicsData = player.actorCharacter.CurrentPhysicsData;

        //float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        //player.actorPhysics.Move(dir * Time.deltaTime * moveSpeed);

        
        if (Input.GetKeyDown(KeyCode.Space) && player.actorCharacter.IsGrounded)
        {
            player.actorCharacter.SetGravityValue(physicsData.jumpPower.Default);
            //player.actorPhysics.AddForce(Vector3.up * physicsData.jumpPower.Default, ForceMode.Impulse);
        }

        if ((player.actorCharacter.IsGrounded && player.actorCharacter.GravityValue < 0F) 
            ||(player.actorCharacter.IsCollidedAbove && player.actorCharacter.GravityValue > 0F))
        {
            player.actorCharacter.SetGravityValue(0F);
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
