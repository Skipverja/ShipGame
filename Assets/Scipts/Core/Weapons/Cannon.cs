using Mirror;
using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class Cannon : MonoBehaviour, IWeapon
    {
        public float cooldown = 3f;
        public float bulletForce = 10f;

        public GameObject cannonball;

        public float Cooldown => cooldown;

        public void Shoot(GameObject[] emitters)
        {
            foreach (GameObject emitter in emitters)
            {
                for (int i = -1; i < 2; i++)
                {
                    GameObject shell = Instantiate(
                        cannonball,
                        emitter.transform.position,
                        emitter.transform.rotation
                    );
                    var shellRigidbody = shell.GetComponent<Rigidbody>();

                    shellRigidbody.AddForce(
                        shell.transform.forward * bulletForce +
                        shell.transform.right * i
                    );

                    NetworkServer.Spawn(shell);
                }
            }
        }
    }
}