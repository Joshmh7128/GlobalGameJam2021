using UnityEngine;

namespace Alex_scripts
{
    public static class ShaderConstants
    {
        public static readonly int MainTexture = Shader.PropertyToID("_MainTex");
        public static readonly int PlayerPosition = Shader.PropertyToID("_PlayerPos");
    }
}