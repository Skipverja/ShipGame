using Scipts.Core.Ships;
using UnityEngine;

namespace Scipts.Core.Weapons
{
    public class Cannon : MonoBehaviour, IWeapon
    {
        public float startingAngle = 30f;
        public float cooldown = 3f;
        public float bulletForce = 10f;
        
        public float Cooldown => cooldown;
        public void Shoot(GameObject[] emitters, GameObject cannonball)
        {
            foreach (GameObject emitter in emitters)
            {
                Quaternion shellRotation = emitters[0].transform.rotation;
                shellRotation.x = startingAngle;
                
                GameObject shell = Instantiate(cannonball, emitter.transform.position, shellRotation);
                var shellRigidbody = shell.GetComponent<Rigidbody>();
            
                shellRigidbody.AddForce(shell.transform.forward * bulletForce);
            }
        }
    }
}