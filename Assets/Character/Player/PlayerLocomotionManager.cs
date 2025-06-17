using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        PlayerManager playerManager;
        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;
        [SerializeField] private float walkingSpeed = 2;
        [SerializeField] private float runningSpeed = 5;
        [SerializeField] private float rotationSpeed = 15;

        private Vector3 moveDirection;
        private Vector3 targetRotationDirection;

        protected override void Awake()
        {
            base.Awake();
            playerManager = GetComponent<PlayerManager>();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotattion();
        }

        public void GetVerticalAndHorizontalInput()
        {
            verticalMovement = PlayerInputManager.Instance.verticalInput;
            horizontalMovement = PlayerInputManager.Instance.horizontalInput;
        }

        private void HandleGroundedMovement()
        {
            GetVerticalAndHorizontalInput();
            //our movement based on camera direction
            moveDirection = PlayerCamera.Instance.transform.forward * verticalMovement;
            moveDirection = PlayerCamera.Instance.transform.right * horizontalMovement;
            moveDirection.Normalize();
            moveDirection.y = 0;
            if (PlayerInputManager.Instance.moveAmount > 0.5f)
            {
                //Running speed
                playerManager.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
            } else if (PlayerInputManager.Instance.moveAmount <= 0.5f)
            {
                playerManager.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
            }
        }

        private void HandleRotattion()
        {
            targetRotationDirection = Vector3.zero;
            targetRotationDirection = PlayerCamera.Instance.cameraObject.transform.forward * verticalMovement;
            targetRotationDirection += PlayerCamera.Instance.cameraObject.transform.right * horizontalMovement;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            if (targetRotationDirection == Vector3.zero)
            {
                targetRotationDirection = transform.forward;
            }
            Quaternion newRotation = Quaternion.LookRotation(targetRotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            this.transform.rotation = targetRotation;
        }
    }
}