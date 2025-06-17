using System;
using Unity.Netcode;
using UnityEngine;

namespace Character
{
    public class CharacterManager : NetworkBehaviour
    {
        public CharacterController characterController;
        private CharacterNetworkManager _characterNetworkManager;
        public virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            characterController = GetComponent<CharacterController>();
            _characterNetworkManager = GetComponent<CharacterNetworkManager>();
        }

        protected virtual void Update()
        {
            if (IsOwner)
            {
                _characterNetworkManager.networkPosition.Value = transform.position;
                _characterNetworkManager.networkRotation.Value = transform.rotation;
            }
            else
            {
                //POSITION
                transform.position = Vector3.SmoothDamp(this.transform.position,
                    _characterNetworkManager.networkPosition.Value, 
                    ref _characterNetworkManager.networkPositionVelocity, _characterNetworkManager.networkPositionSmoothTime);
                //ROTATION
                transform.rotation = Quaternion.Slerp(transform.rotation, _characterNetworkManager.networkRotation.Value,
                    _characterNetworkManager.networkRotationSmoothTime);
            }
        }
    }
}