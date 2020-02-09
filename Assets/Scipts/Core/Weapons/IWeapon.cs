using UnityEngine;

namespace Scipts.Core.Ships
{
    public interface IWeapon
    {
        float Cooldown { get; }

        // TODO: Remove second parameter.
        void Shoot(Transform[] emitters, GameObject cannonball);
    }
}