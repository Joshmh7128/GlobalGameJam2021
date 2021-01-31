using UnityEngine;

namespace Alex_scripts.Scripts
{
    public class LerpPosFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField] [Range(0f, 1f)] private float tau = 0.95f;

        [SerializeField]
        private bool lockX, lockY, lockZ;
        
        void Update()
        {
            Vector3 newPos = transform.position;
            var position = target.position;
            newPos.x = lockX ? newPos.x : Mathf.Lerp(newPos.x, position.x, tau);
            newPos.y = lockY ? newPos.y : Mathf.Lerp(newPos.y, position.y, tau);
            newPos.z = lockZ ? newPos.z : Mathf.Lerp(newPos.z, position.z, tau);
            transform.position = newPos;
        }
    }
}
