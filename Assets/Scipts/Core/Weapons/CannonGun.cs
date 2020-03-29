using System;
using Mirror;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class CannonGun : MonoBehaviour, IWeapon
    {
        public float cooldown = 0.5f;
        public float reloadCooldown = 6f;
        public float bulletForce = 10f;
        public int bulletsBeforeReload = 6;

        public int bulletsLeft;

        public GameObject cannonball;

        public float Cooldown => bulletsLeft == 0 ? reloadCooldown : cooldown;

        public void Start()
        {
            bulletsLeft = bulletsBeforeReload;
        }

        public void Shoot(GameObject[] emitters)
        {
            bulletsLeft--;

            if (bulletsLeft < 0)
            {
                bulletsLeft = bulletsBeforeReload;
            }

            GameObject emitter = emitters[bulletsLeft % emitters.Length];
            GameObject shell = Instantiate(cannonball, emitter.transform.position, emitter.transform.rotation);
            
            var shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(shell.transform.forward * bulletForce);

            NetworkServer.Spawn(shell);
        }
    }
}