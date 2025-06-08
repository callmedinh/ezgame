using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class ManualInput : MonoBehaviour
    {
        public InputActionAsset inputAction;
        private InputAction _mouse;
        private InputAction _moveAction;

        private Vector2 _moveInput;
        
        [SerializeField] private PlayerCharacter playerCharacter;

        private void Awake()
        {
            var gameplay = inputAction.FindActionMap(GameConstants.GameplayActionMap);
            if (gameplay == null) Debug.LogWarning("No Gameplay found");
            _moveAction = gameplay.FindAction(GameConstants.MoveAction);
            if (_moveAction == null) Debug.LogWarning("No action found");
            _moveAction.Enable();
        }  

        private void Start()
        {
            if (playerCharacter == null) Debug.LogWarning("No player character found");
        }

        private void Update()
        {
            _moveInput = _moveAction.ReadValue<Vector2>();
            Debug.Log($"Move Input: {_moveInput}");
            if (_moveInput != Vector2.zero)
            {
                playerCharacter.Move(_moveInput);
            }
        }
    }
}