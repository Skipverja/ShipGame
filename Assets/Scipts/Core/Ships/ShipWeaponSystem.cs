using System.Collections.Generic;
using System.Linq;
using Mirror;
using Scipts.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(IPlayerInput))]
    public class ShipWeaponSystem : NetworkBehaviour
    {
        private IPlayerInput _playerInput;

        private float[] _nextShootTimeByWeapon;

        public int selectedWeapon = 0;

        public GameObject shellEmitter;

        public List<GameObject> weaponsObjects;
        
        private IWeapon[] _weapons;

        public void Start()
        {
            _playerInput = GetComponent<IPlayerInput>();
            
            _weapons = weaponsObjects
                .Select(w => w.GetComponent<IWeapon>())
                .ToArray();

            _nextShootTimeByWeapon = _weapons
                .Select(_ => Time.time)
                .ToArray();
        }

        public void Update()
        {
            if (!_playerInput.Shooting || !(Time.time >= _nextShootTimeByWeapon[selectedWeapon])) 
                return;

            _nextShootTimeByWeapon[selectedWeapon] = Time.time + _weapons[selectedWeapon].Cooldown;

            CmdShoot();
        }

        [Command]
        private void CmdShoot()
        {
            _weapons[selectedWeapon].Shoot(new[] {shellEmitter});
        }
    }
}