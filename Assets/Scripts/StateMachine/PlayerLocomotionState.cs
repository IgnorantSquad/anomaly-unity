using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerLocomotionState : State
{
    public override Identity ID => State.Identity.PlayerLocomotion;

    private Vector3 handlePos = new Vector3(5F, 0.5f, -10F);

    private CharacterComponent character;
    private CameraComponent camera;


    public override void OnEnter(CustomBehaviour target)
    {
        character = target.GetSharedComponent<CharacterComponent>();
        camera = target.GetSharedComponent<CameraComponent>();
    }

    public override void OnExit(CustomBehaviour target)
    {

    }

    public override void OnFixedUpdate(CustomBehaviour target)
    {
        var player = target as Player;
        var physicsData = player.characterData.physicsData;

        character.CalculateGravity(player.characterData);

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, player.characterData.gravityValue, 0F);
        Vector3 slideVector = character.GetSlideVector(player.characterData, player.transform, 2F);

        if (Mathf.Abs(moveDir.x + slideVector.x) < Mathf.Abs(moveDir.x) && moveDir.y <= 0F)
        {
            moveDir.x = 0F;
        }

        moveDir += slideVector;

        //player.actorPhysics.Move(moveDir * Time.deltaTime * moveSpeed);
        character.Move(player.characterData, moveDir);
    }

    public override void OnUpdate(CustomBehaviour target)
    {
        var player = target as Player;
        var physicsData = player.characterData.physicsData;

        
        if (Input.GetKeyDown(KeyCode.Space) && player.characterData.IsGrounded)
        {
            player.characterData.gravityValue = physicsData.jumpPower.Default;
            //player.actorPhysics.AddForce(Vector3.up * physicsData.jumpPower.Default, ForceMode.Impulse);
        }

        if ((player.characterData.IsGrounded && player.characterData.gravityValue < 0F) 
            || (player.characterData.IsCollidedAbove && player.characterData.gravityValue > 0F))
        {
            player.characterData.gravityValue = 0F;
        }

        //if (moveDir.x > 0F) handlePos = new Vector3(2.5f, 0.5f, -10F);
        //else if (moveDir.x < 0F) handlePos = new Vector3(-2.5f, 0.5f, -10F);
        if (Input.mousePosition.x > Screen.width * 0.65f) handlePos = new Vector3(2.5F, 0.5f, -10F);
        else if (Input.mousePosition.x < Screen.width * 0.35f) handlePos = new Vector3(-2.5F, 0.5f, -10F);
        //handlePos = moveDir.x > 0F ? new Vector3(5F, 0.5f, -10F) : moveDir.x < 0F ? new Vector3(-5F, 0.5f, -10F) : handlePos;

        camera.SetCameraHandlePosition(player.cameraData, handlePos);
        //player.actorCamera.SetCameraHandlePosition(new Vector3(5F * h, 0.5f, -10F));
    }

    public override void OnLateUpdate(CustomBehaviour target)
    {

    }
}
