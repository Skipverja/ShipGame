using Scipts.Input;
using UnityEngine;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(IPlayerInput))]
    public class ShipWeaponSystem : MonoBehaviour
    {
        private IPlayerInput _playerInput;

        private float _nextShootTime;

        public Transform shellEmitter;

        public GameObject cannonball;

        public IWeapon weapon;

        public void Start()
        {
            _nextShootTime = Time.time;
            _playerInput = GetComponent<IPlayerInput>();
        }

        public void Update()
        {
            if (!_playerInput.Shooting || !(Time.time >= _nextShootTime)) return;
            
            _nextShootTime = Time.time + weapon.Cooldown;
            weapon.Shoot(new[] {shellEmitter}, cannonball);
        }
    }
}