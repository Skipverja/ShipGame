using UnityEngine;

namespace Scipts.Core
{
    public class BottomCollisionHandler : MonoBehaviour
    {
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(Tags.BulletTag)){
                Destroy(other.gameObject);
            }   
        }
    }
}