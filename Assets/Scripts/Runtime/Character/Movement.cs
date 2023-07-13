using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Runtime.Character
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
    public class Movement : MonoBehaviour
    {
        // Serialize Variables
        [SerializeField] private PlayerSettings _settings;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private PlayerInput _playerInput;

        // Input Actions
        private InputAction _moveAction;

        // Raw Inputs
        private Vector2 _rawMovementInput;

        // Movement Direction
        private Vector2 _targetDirection;

        /// <summary>
        /// Process the player's input
        /// </summary>
        private void ProcessInput()
        {
            _targetDirection = _rawMovementInput.normalized;
        }

        /// <summary>
        /// Process Player's movement
        /// </summary>
        private void ProcessMovement()
        {
            Vector2 movementForce = _targetDirection * _settings.Speed;
            _rb.velocity = movementForce;
        }

        void Awake()
        {
            // Fetches components if null
            if (_rb == null) _rb = GetComponent<Rigidbody2D>();
            if (_playerInput == null) _playerInput = GetComponent<PlayerInput>();

            // Sets input actions
            _moveAction = _playerInput.actions["Movement"];

            // Sets callbacks for player input
            _moveAction.performed += e => _rawMovementInput = e.ReadValue<Vector2>();
            _moveAction.canceled += e => _rawMovementInput = e.ReadValue<Vector2>();
        }

        private void Update()
        {
            // Process Inputs
            ProcessInput();
        }

        private void FixedUpdate()
        {
            // Movement Calculations
            ProcessMovement();
        }
    }
}