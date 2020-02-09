using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class Cannon : MonoBehaviour, IWeapon
    {
        public float cooldown = 3f;
        public float bulletForce = 10f;
        
        public float Cooldown => cooldown;
        public void Shoot(Transform[] emitters, GameObject cannonball)
        {
            GameObject shell = Instantiate(cannonball, emitters[0]);
            var shellRigidbody = shell.GetComponent<Rigidbody>();
            
            shellRigidbody.AddForce(emitters[0].forward * bulletForce);
        }
    }
}