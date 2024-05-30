Shader "Graph/PointSurface"
{
    Properties
    {
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }

    SubShader
    {
        CGPROGRAM
        #pragma surface ConfigureShader Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float3 worldPos;
        };

        float _Smoothness;

        void ConfigureShader (Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo.rg = saturate(input.worldPos.xy * 0.5 + 0.5);
            surface.Smoothness = _Smoothness;
        }
        ENDCG
    }

    Fallback "Diffuse"
}
