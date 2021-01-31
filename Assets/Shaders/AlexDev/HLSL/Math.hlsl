#ifndef SHADER_MATH
#define SHADER_MATH

    inline float InvLerp(float a, float b, float val)
    {
        return (val - a) / (b - a);
    }

    inline float4 InvLerp(float a, float b, float4 val)
    {
        return (val - a) / (b - a);
    }
    
    inline float Remap(float val, float oldA, float oldB, float newA, float newB) {
        float tau = InvLerp(oldA, oldB, val);
        return lerp(newA, newB, tau);
    }

    inline float4 Remap(float4 val, float oldA, float oldB, float newA, float newB) {
        float4 tau = InvLerp(oldA, oldB, val);
        return lerp(newA, newB, tau);
    }
 
    inline float Posterize(float steps, float val) {
        return round(val * steps) / steps;
    }

    inline float dist(float x, float y) {
        return abs(x - y);
    }

#endif