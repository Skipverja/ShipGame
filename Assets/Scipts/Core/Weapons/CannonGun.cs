using System;
using Mirror;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class CannonGun : MonoBehaviour, IWeapon
    {
        public float cooldown = 0.1f;
        public float reloadCooldown = 5f;
        public float bulletForce = 10f;
        public int bulletsBeforeReload = 30;
        
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
            
            foreach (GameObject emitter in emitters)
            {
                GameObject shell = Instantiate(cannonball, emitter.transform.position, emitters[0].transform.rotation);
                var shellRigidbody = shell.GetComponent<Rigidbody>();

                shellRigidbody.AddForce(shell.transform.forward * bulletForce);

                NetworkServer.Spawn(shell);
            }
        }
    }
}