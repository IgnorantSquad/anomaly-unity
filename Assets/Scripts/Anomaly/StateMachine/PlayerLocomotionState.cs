using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anomaly
{
    public class PlayerLocomotionState : State
    {
        public override Identity ID => State.Identity.PlayerLocomotion;

        private Vector3 moveDir = Vector3.zero;
        private float gravity = 0F;

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
        }

        public override void OnLateUpdate(CustomBehaviour target)
        {

        }
    }
}