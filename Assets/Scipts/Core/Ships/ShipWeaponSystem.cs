using Scipts.Input;
using UnityEngine;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(IPlayerInput))]
    [RequireComponent(typeof(IWeapon))]
    public class ShipWeaponSystem : MonoBehaviour
    {
        private IPlayerInput _playerInput;

        private IWeapon _weapon;

        private float _nextShootTime;

        public Transform shellEmitter;

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
            _weapon.Shoot(new[] {shellEmitter}, cannonball);
        }
    }
}