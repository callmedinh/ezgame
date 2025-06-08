using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody rigibody;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 move)
    {
        Vector2 direction = this.transform.forward * move.y + transform.right * move.x;
        rigibody.linearVelocity = new Vector3(direction.x, rigibody.linearVelocity.y, direction.y);
    }
}
