using System;
using Mirror;
using Scipts.Animation;
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

        [SyncVar]
        private bool _isFreezed;

        public bool isFreezed
        {
            get { return _isFreezed; }
            set { _isFreezed = value; CmdChangeIsFreezed(value); }
        }


        public void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();

            CameraFollow.Instance.Follow(_transform);
        }

        public void Update()
        {
            if (isFreezed) return;

            _rigidbody.AddForce(_playerInput.Acceleration * speed * transform.forward);

            _transform.Rotate(
                0f,
                rotationSpeed * _playerInput.Rotation * Mathf.Min(_rigidbody.velocity.magnitude, 1f),
                0f
                );

        }

        [Command]
        public void CmdChangeIsFreezed(bool value)
        {
            _isFreezed = value;
        }

        private void OnDestroy()
        {
            CameraFollow.Instance.Unfollow(_transform);
        }
    }
}