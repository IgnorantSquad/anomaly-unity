using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anomaly;


public class PlayerLocomotionState : State<Player>
{
    public override StateID ID => StateID.PlayerLocomotion;

    private Vector3 handlePos = new Vector3(5F, 0.5f, -10F);

    private CharacterComponent character;
    private CameraComponent camera;


    public override void OnEnter(Player target)
    {
        character = target.Character;
        camera = target.Camera;
    }

    public override void OnExit(Player target)
    {

    }


    public override bool IsTransition(Player target, out StateID next)
    {
        next = StateID.None;
        return false;
    }


    public override void OnFixedUpdate(Player target)
    {
        var physicsData = target.Character.PhysicsData;

        character.CalculateGravity();

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? physicsData.moveSpeed.Get("Run") : physicsData.moveSpeed.Default;

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, target.Character.Gravity.value, 0F);
        Vector3 slideVector = character.GetSlideVector(target.transform, 2F);

        if (Mathf.Abs(moveDir.x + slideVector.x) < Mathf.Abs(moveDir.x) && moveDir.y <= 0F)
        {
            moveDir.x = 0F;
        }

        moveDir += slideVector;

        //target.actorPhysics.Move(moveDir * Time.deltaTime * moveSpeed);
        character.Move(moveDir);
    }

    public override void OnUpdate(Player target)
    {
        var physicsData = target.Character.PhysicsData;


        if (Input.GetKeyDown(KeyCode.Space) && target.Character.IsGrounded)
        {
            target.Character.SetGravityValue(physicsData.jumpPower.Default);
            //target.actorPhysics.AddForce(Vector3.up * physicsData.jumpPower.Default, ForceMode.Impulse);
        }

        if ((target.Character.IsGrounded && target.Character.Gravity.value < 0F)
            || (target.Character.IsCollidedAbove && target.Character.Gravity.value > 0F))
        {
            target.Character.SetGravityValue(0F);
        }

        //if (moveDir.x > 0F) handlePos = new Vector3(2.5f, 0.5f, -10F);
        //else if (moveDir.x < 0F) handlePos = new Vector3(-2.5f, 0.5f, -10F);
        if (Input.mousePosition.x > Screen.width * 0.65f) handlePos = new Vector3(2.5F, 0.5f, -10F);
        else if (Input.mousePosition.x < Screen.width * 0.35f) handlePos = new Vector3(-2.5F, 0.5f, -10F);
        //handlePos = moveDir.x > 0F ? new Vector3(5F, 0.5f, -10F) : moveDir.x < 0F ? new Vector3(-5F, 0.5f, -10F) : handlePos;

        camera.SetCameraHandlePosition(handlePos);
        //target.actorCamera.SetCameraHandlePosition(new Vector3(5F * h, 0.5f, -10F));
    }

    public override void OnLateUpdate(Player target)
    {

    }
}
