using Mirror;
using Scipts.Input;
using UnityEngine;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(PlayerInput))]
    public class ShipMovement : NetworkBehaviour
    {
        private PlayerInput _playerInput;
        private Transform _transform;
        private Rigidbody _rigidbody;

        public float speed = 11f;
        public float rotationSpeed = 0.25f;

        public void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        public void Update()
        {
            _rigidbody.AddForce(_playerInput.Acceleration * speed * transform.forward);

            _transform.Rotate(
                0f,
                rotationSpeed * _playerInput.Rotation * Mathf.Min(_rigidbody.velocity.magnitude, 1f),
                0f
            );
        }
    }
}