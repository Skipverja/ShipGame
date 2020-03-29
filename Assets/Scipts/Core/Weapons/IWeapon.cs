using UnityEngine;

namespace Scipts.Core.Ships
{
    public interface IWeapon
    {
        float Cooldown { get; }

        void Shoot(GameObject[] emitters);
    }
}