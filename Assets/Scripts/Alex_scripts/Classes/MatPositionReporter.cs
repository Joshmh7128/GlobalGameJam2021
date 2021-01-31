using System;
using Alex_scripts.Interfaces;
using UnityEngine;

namespace Alex_scripts.Classes
{
    [Serializable]
    public class MatPositionReporter : IListener<Vector3>
    {
        public static readonly int PlayerPositionShader = ShaderConstants.PlayerPosition;
        [SerializeField]
        private Material material;
        
        public void HandleEvent(Vector3 data)
        {
            material.SetVector(PlayerPositionShader, data);
        }
    }
}