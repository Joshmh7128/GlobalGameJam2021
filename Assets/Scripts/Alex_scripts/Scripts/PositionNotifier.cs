using Alex_scripts.Classes;
using UnityEngine;

namespace Alex_scripts.Scripts
{
    public class PositionNotifier : MonoBehaviour
    {
        [SerializeField]
        private MatPositionReporter[] listeners;

        private void Update()
        {
            foreach (MatPositionReporter listener in listeners)
            {
                listener.HandleEvent(transform.position);
            }
        }
    }
}