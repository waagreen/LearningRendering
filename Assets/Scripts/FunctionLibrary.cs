using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate Vector3 Function(float u, float v, float t);
    
    public enum FunctionName {SinWave, MultiSinWave, OutBounce, InBounce, RippleWave, TwistedSphere, Thorus};
    static readonly Function[] Functions = {SinWave, MultiSinWave, OutBounce, InBounce, RippleWave, TwistedSphere, Thorus};

    public static Function GetFunction(FunctionName name)
    {
        return Functions[(int)name];
    }

    public static Vector3 SinWave(float u, float v, float t)
    {   
        Vector3 p = Vector3.zero;
        
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        
        return p;
    }

    public static Vector3 MultiSinWave(float u, float v, float t)
    {        
        Vector3 p = Vector3.zero;
        
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (u + 0.5f * t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        
        return p;
    }

    public static Vector3 OutBounce(float u, float v, float t)
    {        
        Vector3 p = Vector3.zero;

        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (u < 1f / d1) p.y = n1 * u * u;
        else if (u < 2f / d1) p.y = n1 * (u -= 1.5f / d1) * u + 0.75f;
        else if (u < 2.5f / d1) p.y = n1 * (u -= 2.25f / d1) * u + 0.9375f;
        else p.y = n1 * (u -= 2.625f / d1) * u + 0.984375f; 
        
        p.x = u;
        p.z = v;
        
        return p;
    }

    public static Vector3 InBounce(float u, float v, float t)
    {   
        return OutBounce(1 - u, v, t);
    }

    public static Vector3 RippleWave(float u, float v, float t)
    {
        Vector3 p = Vector3.zero;
        float d = Sqrt(u * u + v * v);
        
        p.x = u;
        p.y = Sin(PI * (6f * d - t));
        p.y /= 2f + 10f * d;
        p.z = v;

        return p;
    }

    public static Vector3 Sphere(float u, float v)
    {
        Vector3 p = Vector3.zero;

        float r = Cos(PI / 2 * v);

        p.x = Sin(PI * u);
        p.y = Sin(PI / 2 * v);
        p.z = Cos(PI * u);

        return p;
    }

    public static Vector3 TwistedSphere(float u, float v, float t)
    {
        Vector3 p = Vector3.zero;
       
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);

        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);

        return p;
    }

    public static Vector3 Thorus(float u, float v, float t)
    {
        Vector3 p = Vector3.zero;
       
        float r1 = 1.2f + 0.2f * Sin(PI * (6f * u + t * 0.4f));
        float r2 = 0.2f + 0.025f * Sin(PI * (8f * u + 4f * v + 1.75f * t));

        float s = r1 + r2 * Cos(PI * v);

        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);

        return p;
    }
}
