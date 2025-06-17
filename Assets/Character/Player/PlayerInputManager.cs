using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Utilities;

namespace Character.Player
{
    public class PlayerInputManager : Singleton<PlayerInputManager>
    {
        public InputActionAsset inputAsset;
        private InputAction _moveAction;
        private InputAction _attackAction;

        private Vector2 _movement;

        private void Awake()
        {
            SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
            Instance.enabled = false;
        }

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
            Instance.enabled = false;
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
    }
}