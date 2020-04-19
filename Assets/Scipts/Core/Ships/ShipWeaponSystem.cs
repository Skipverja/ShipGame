using System.Collections.Generic;
using System.Linq;
using Mirror;
using Scipts.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scipts.Core.Ships
{
    [RequireComponent(typeof(PlayerInput))]
    public class ShipWeaponSystem : NetworkBehaviour
    {
        private PlayerInput _playerInput;

        private float[] _nextShootTimeByWeapon;

        [SyncVar] public int selectedWeapon = 0;

        public List<GameObject> shellEmitters;

        public List<GameObject> weaponsObjects;

        private IWeapon[] _weapons;

        public void Start()
        {
            _playerInput = GetComponent<PlayerInput>();

            _weapons = weaponsObjects
                .Select(w => w.GetComponent<IWeapon>())
                .ToArray();

            _nextShootTimeByWeapon = _weapons
                .Select(_ => Time.time)
                .ToArray();
        }

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                selectedWeapon--;
                if (selectedWeapon < 0)
                {
                    selectedWeapon = _weapons.Length - 1;
                }
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                selectedWeapon++;
                if (selectedWeapon >= _weapons.Length)
                {
                    selectedWeapon = 0;
                }
            }
            
            if (!_playerInput.Shooting || !(Time.time >= _nextShootTimeByWeapon[selectedWeapon]))
                return;

            _nextShootTimeByWeapon[selectedWeapon] = Time.time + _weapons[selectedWeapon].Cooldown;

            CmdShoot();
        }

        [Command]
        private void CmdShoot()
        {
            _weapons[selectedWeapon].Shoot(shellEmitters.ToArray());
        }
    }
}