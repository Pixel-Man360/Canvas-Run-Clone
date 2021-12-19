using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control options: ")]
    [SerializeField] private float _forwardSpeed = 300f;
    [SerializeField] private float _sidewaysSpeed = 100f;

    [Header("Dependecies: ")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody _rb;
    
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        MoveForward();
        MoveSideways();
        
    }

    void MoveForward()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _forwardSpeed * Time.fixedDeltaTime);
    }

    void MoveSideways()
    {
        if(Input.GetMouseButton(0))
        {
            _rb.velocity = new Vector3(_sidewaysSpeed * _playerInput.MouseX * Time.fixedDeltaTime, _rb.velocity.y, _rb.velocity.z); 
        }
    }
}
