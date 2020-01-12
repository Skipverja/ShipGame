using System;
using Scipts.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scipts
{
    [RequireComponent(typeof(IPlayerInput))]
    [RequireComponent(typeof(Rigidbody))]
    public class ShipMovement : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private Rigidbody _rigidbody;
        private Transform _transform;

        public float speed = 11f;
        public float rotationSpeed = 0.25f;

        public void Start()
        {
            _playerInput = GetComponent<IPlayerInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        public void Update()
        {
            _rigidbody.AddForce(_playerInput.Acceleration * speed * transform.forward);

            _transform.Rotate(0f, rotationSpeed * _playerInput.Rotation * Mathf.Min(_rigidbody.velocity.magnitude, 1f), 0f);
        }
    }
}