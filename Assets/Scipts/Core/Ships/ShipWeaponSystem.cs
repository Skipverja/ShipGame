using Mirror;
using Scipts.Input;
using UnityEngine;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(IPlayerInput))]
    [RequireComponent(typeof(IWeapon))]
    public class ShipWeaponSystem : NetworkBehaviour
    {
        private IPlayerInput _playerInput;

        private IWeapon _weapon;

        private float _nextShootTime;

        public GameObject shellEmitter;

        public GameObject cannonball;

        public void Start()
        {
            _nextShootTime = Time.time;
            _playerInput = GetComponent<IPlayerInput>();
            _weapon = GetComponent<IWeapon>();
        }

        public void Update()
        {
            if (!_playerInput.Shooting || !(Time.time >= _nextShootTime)) return;
            
            _nextShootTime = Time.time + _weapon.Cooldown;

            CmdShoot();
        }

        [Command]
        private void CmdShoot()
        {
            _weapon.Shoot(new[] {shellEmitter}, cannonball);
        }
    }
}