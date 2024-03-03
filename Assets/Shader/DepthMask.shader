Shader "DepthMask"
{
    Properties
    {
    }
    SubShader
    {
        Tags 
        { 
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Opaque"
            "Queue"="Geometry+0"
        }
        ZWrite On
        ColorMask 0
        Cull Off
        pass{}
    }
}
