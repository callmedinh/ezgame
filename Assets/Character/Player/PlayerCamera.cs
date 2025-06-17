using System;
using UnityEngine;
using Utilities;

namespace Character.Player
{
    public class PlayerCamera : Singleton<PlayerCamera>
    {
        public Camera cameraObject;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}