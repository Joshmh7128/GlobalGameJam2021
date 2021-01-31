Shader "Unlit/OverheadMapShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BgTex ("Background Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0.0, 10.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Assets/Shaders/AlexDev/HLSL/SobelFilter.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            sampler2D _BgTex;
            float4 _BgTex_ST;

            float4 _OutlineColor;
            float _OutlineWidth;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 bgCol = tex2D(_BgTex, i.uv);
                float tau = step(col.a, 0.5);
                col = lerp(col, bgCol, tau);
                
                float4 outlineTau = getSobel(_MainTex, i.uv, _OutlineWidth);
                tau = max(max(max(outlineTau.x, outlineTau.y), outlineTau.z), outlineTau.w);
                col = lerp(col, _OutlineColor, tau);
                
                return col;
            }
            ENDCG
        }
    }
}
