using UnityEngine;

namespace Alex_scripts.Scripts
{
    public class LerpRotFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField] private float defaultRot;

        void Update()
        {
            float yaw = target.rotation.eulerAngles.y;
            var eulerAngles = transform.eulerAngles;
            eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, defaultRot + yaw);
            transform.eulerAngles = eulerAngles;
        }
    }
}
