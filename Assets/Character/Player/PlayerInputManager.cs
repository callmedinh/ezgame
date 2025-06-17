using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Character.Player
{
    public class PlayerInputManager : Utilities.Singleton<PlayerInputManager>
    {
        public InputActionAsset inputAsset;
        private InputAction _moveAction;
        private InputAction _attackAction;

        private Vector2 _movement;
        public float verticalInput;
        public float horizontalInput;
        public float moveAmount;

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
            Instance.enabled = false;
        }

        private void Update()
        {
            HandleMovementInput();
        }

        private void SceneManagerOnactiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.buildIndex == WorldSaveGameManager.Instance.GetWorldSceneIndex())
            {
                Instance.enabled = true;
            }
            else
            {
                Instance.enabled = false;
            }
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnactiveSceneChanged;
        }

        private void OnEnable()
        {
            InputActionMap actionMap = inputAsset.FindActionMap(GameConstants.GameplayActionMap);
            if (actionMap == null) return;
            _moveAction = actionMap.FindAction(GameConstants.MoveAction);
            _attackAction = actionMap.FindAction(GameConstants.AttackAction);
            if (_moveAction == null) return;
            if (_attackAction == null) return; 
            _moveAction.performed += ctx => _movement = ctx.ReadValue<Vector2>();
        }

        //IF MINIMIZE OR LOWER WINDOW, STOP ADJUSTING INPUTS
        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Instance.enabled = true;
            }
            else
            {
                Instance.enabled = false;
            }
        }

        void HandleMovementInput()
        {
            verticalInput = _movement.y;
            horizontalInput = _movement.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
            if (moveAmount <= 0.5f && moveAmount > 0f)
            {
                moveAmount = .5f;
            }else if (moveAmount > .5f && moveAmount < 1f)
            {
                moveAmount = 1f;
            }
        }
    }
}