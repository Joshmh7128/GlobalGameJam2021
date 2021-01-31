#ifndef SOBEL_FILTER_HLSL
#define SOBEL_FILTER_HLSL

    #include "UnityCG.cginc"

    inline float4 getSobel(sampler2D tex, float2 uv, float width) {
        // Get the rate of change for each pixel.
        float hInterval = 1.0 / _ScreenParams.x * width;
        float vInterval = 1.0 / _ScreenParams.y * width;
        fixed3x3 Gx = fixed3x3(
            1,	0,	-1,
            2,	0,	-2,
            1,	0,	-1
        );
        fixed3x3 Gy = fixed3x3(
            1,	2,	1,
            0,	0,	0,
            -1,	-2,	-1
        );
        
        float4 magGx = 0;
        float4 magGy = 0;
        //float l = tex2D(tex, uv).w * 9.0;
        for (int r = 0; r < 3; r++) {
            float dx = (r - 1) * hInterval;
            for (int c = 0; c < 3; c++) {
                float dy = (c - 1) * vInterval;
                magGx += tex2D(tex, float2(uv.x + dx, uv.y + dy)) * Gx[2 - r][2 - c];
                magGy += tex2D(tex, float2(uv.x + dx, uv.y + dy)) * Gy[2 - r][2 - c];
                //l -= tex2D(tex, uv).w;
            }
        }

        //l /= 3.0;
        return abs(magGx) + abs(magGy);
    }

#endif