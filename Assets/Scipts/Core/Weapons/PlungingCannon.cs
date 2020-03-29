using Mirror;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class PlungingCannon : MonoBehaviour, IWeapon
    {
        public float cooldown = 3f;
        public float bulletForce = 5f;
        public float upForce = 20f;

        public GameObject cannonball;

        public float Cooldown => cooldown;

        public void Shoot(GameObject[] emitters)
        {
            foreach (GameObject emitter in emitters)
            {
                GameObject shell = Instantiate(cannonball, emitter.transform.position, emitter.transform.rotation);
                var shellRigidbody = shell.GetComponent<Rigidbody>();

                shellRigidbody.AddForce(shell.transform.forward * bulletForce + shell.transform.up * upForce);

                NetworkServer.Spawn(shell);
            }
        }
    }
}