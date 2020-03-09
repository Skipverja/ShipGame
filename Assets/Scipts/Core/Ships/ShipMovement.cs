using Mirror;
using Scipts.Input;
using UnityEngine;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(IPlayerInput))]
    [RequireComponent(typeof(PhysicsLink))]
    public class ShipMovement : NetworkBehaviour
    {
        private IPlayerInput _playerInput;
        private Transform _transform;
        private PhysicsLink _physicsLink;

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
            _playerInput = GetComponent<IPlayerInput>();
            _physicsLink = GetComponent<PhysicsLink>();
            _transform = GetComponent<Transform>();
        }

        public void Update()
        {
            if (!isFreezed){
                _physicsLink.AddForce(_playerInput.Acceleration * speed * transform.forward);

                _transform.Rotate(
                    0f,
                    rotationSpeed * _playerInput.Rotation * Mathf.Min(_physicsLink.Velocity.magnitude, 1f),
                    0f
                );
            }
        }

        [Command]
        public void CmdChangeIsFreezed(bool value){
            _isFreezed = value;
        }

    }
}