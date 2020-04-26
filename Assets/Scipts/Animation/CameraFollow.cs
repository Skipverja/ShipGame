using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scipts.Animation
{
    public class CameraFollow : MonoBehaviour
    {
        private List<Transform> followedTransforms = new List<Transform>();

        public static CameraFollow Instance { get; private set; }
        
        public float zoomFactor = 1.5f;
        public float followTimeDelta = 0.8f;
        public float accuracy = 0.05f;
        public float minHeight = 50f;
        
        private Camera _camera;

        private void Start()
        {
            Instance = this;
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (followedTransforms.Count == 0)
            {
                return;
            }

            Vector3[] positions = followedTransforms
                .Select(t => t.position)
                .Append(Vector3.zero)
                .ToArray(); 
            
            Vector3 mid = positions.Aggregate(
                Vector3.zero,
                (current, position) => current + position
            );

            mid /= followedTransforms.Count;

            var distance = 0f;

            for (int i = 0; i < positions.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    float newDistance = (positions[i] - positions[j]).magnitude;
                    distance = Mathf.Max(distance, newDistance);
                }
            }


            Transform cameraTransform = transform;
            Vector3 cameraDestination = mid - cameraTransform.forward * Mathf.Max(minHeight, distance * zoomFactor);
            cameraTransform.position = Vector3.Slerp(cameraTransform.position, cameraDestination, followTimeDelta);

            if ((cameraDestination - cameraTransform.position).sqrMagnitude <= accuracy * accuracy)
            {
                cameraTransform.position = cameraDestination;
            }
        }

        public void Follow(Transform t)
        {
            followedTransforms.Add(t);
        }

        public void Unfollow(Transform t)
        {
            followedTransforms.Remove(t);
        }
    }
}