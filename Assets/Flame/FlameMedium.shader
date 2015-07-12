// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:1,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:False,igpj:True,qofs:1,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32716,y:32678,varname:node_4795,prsc:2|emission-9019-RGB,alpha-3106-OUT;n:type:ShaderForge.SFN_TexCoord,id:3273,x:32155,y:32275,varname:node_3273,prsc:2,uv:0;n:type:ShaderForge.SFN_Color,id:9019,x:31927,y:32717,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9019,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_OneMinus,id:155,x:32315,y:32275,varname:node_155,prsc:2|IN-3273-V;n:type:ShaderForge.SFN_RemapRange,id:7858,x:32468,y:32275,varname:node_7858,prsc:2,frmn:0,frmx:0.8,tomn:0,tomx:1|IN-155-OUT;n:type:ShaderForge.SFN_Clamp01,id:9370,x:32618,y:32275,varname:node_9370,prsc:2|IN-7858-OUT;n:type:ShaderForge.SFN_Power,id:824,x:32802,y:32495,varname:node_824,prsc:2|VAL-9370-OUT,EXP-2149-OUT;n:type:ShaderForge.SFN_Slider,id:510,x:32018,y:32469,ptovrint:False,ptlb:GradientPower,ptin:_GradientPower,varname:node_510,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:2149,x:32332,y:32469,varname:node_2149,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:4|IN-510-OUT;n:type:ShaderForge.SFN_Multiply,id:3106,x:32422,y:32967,varname:node_3106,prsc:2|A-824-OUT,B-9019-A;proporder:9019-510;pass:END;sub:END;*/

Shader "Shader Forge/FlameMedium" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _GradientPower ("GradientPower", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent+1"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Front
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _GradientPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(pow(saturate(((1.0 - i.uv0.g)*1.25+0.0)),(_GradientPower*3.5+0.5))*_Color.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
