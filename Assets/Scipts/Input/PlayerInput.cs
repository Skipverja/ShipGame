using System;
using Mirror;

namespace Scipts.Input
{
    public class PlayerInput : NetworkBehaviour
    {
        [SyncVar] private float _rotation;
        [SyncVar] private float _acceleration;
        [SyncVar] private bool _shooting;


        public float Rotation
        {
            get => _rotation;
            protected set
            {
                _rotation = value;
                CmdSetServerRotation(value);
            }
        }

        public float Acceleration
        {
            get => _acceleration;
            protected set
            {
                _acceleration = value;
                CmdSetServerAcceleration(value);
            }
        }

        public bool Shooting { get; protected set; }
        
        [Command]
        private void CmdSetServerRotation(float value)
        {
            _rotation = value;
        }

        [Command]
        private void CmdSetServerAcceleration(float value)
        {
            _acceleration = value;
        }
    }
}