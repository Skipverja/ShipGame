using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class Cannon : MonoBehaviour, IWeapon
    {
        public float cooldown = 3f;
        public float bulletForce = 10f;
        
        public float Cooldown => cooldown;
        public void Shoot(GameObject[] emitters, GameObject cannonball)
        {
            foreach (GameObject emitter in emitters)
            {
                GameObject shell = Instantiate(cannonball, emitter.transform.position, emitters[0].transform.rotation);
                var shellRigidbody = shell.GetComponent<Rigidbody>();
            
                shellRigidbody.AddForce(shell.transform.forward * bulletForce);
            }
        }
    }
}