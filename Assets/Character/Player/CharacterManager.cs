using System;
using UnityEngine;

namespace Character.Player
{
    public class CharacterManager : MonoBehaviour
    {
        public virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        protected virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}