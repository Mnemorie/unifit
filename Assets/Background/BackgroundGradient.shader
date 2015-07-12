// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-8640-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31742,y:32344,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Color,id:32,x:31528,y:32330,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_32,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:3359,x:31742,y:32515,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:node_3359,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3159,x:31211,y:32871,ptovrint:False,ptlb:Tex1,ptin:_Tex1,varname:node_3159,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2667,x:31211,y:33096,ptovrint:False,ptlb:Tex2,ptin:_Tex2,varname:node_2667,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9237,x:31420,y:33096,ptovrint:False,ptlb:Tex3,ptin:_Tex3,varname:node_9237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8347,x:31761,y:32841,ptovrint:False,ptlb:Tex4,ptin:_Tex4,varname:node_8347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2015,x:31843,y:33096,ptovrint:False,ptlb:Tex5,ptin:_Tex5,varname:node_2015,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8640,x:32428,y:32395,varname:node_8640,prsc:2|A-7241-RGB,B-3359-RGB,T-1415-OUT;n:type:ShaderForge.SFN_Multiply,id:528,x:32096,y:33096,varname:node_528,prsc:2|A-1617-OUT,B-2015-A;n:type:ShaderForge.SFN_Vector1,id:1617,x:32096,y:33038,varname:node_1617,prsc:2,v1:0;n:type:ShaderForge.SFN_Max,id:1415,x:32096,y:32891,varname:node_1415,prsc:2|A-8347-A,B-528-OUT;proporder:7241-3159-2667-9237-8347-2015-3359;pass:END;sub:END;*/

Shader "Shader Forge/BackgroundGradient" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Tex1 ("Tex1", 2D) = "white" {}
        _Tex2 ("Tex2", 2D) = "white" {}
        _Tex3 ("Tex3", 2D) = "white" {}
        _Tex4 ("Tex4", 2D) = "white" {}
        _Tex5 ("Tex5", 2D) = "white" {}
        _Color3 ("Color3", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float4 _Color3;
            uniform sampler2D _Tex4; uniform float4 _Tex4_ST;
            uniform sampler2D _Tex5; uniform float4 _Tex5_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 _Tex4_var = tex2D(_Tex4,TRANSFORM_TEX(i.uv0, _Tex4));
                float4 _Tex5_var = tex2D(_Tex5,TRANSFORM_TEX(i.uv0, _Tex5));
                float node_528 = (0.0*_Tex5_var.a);
                float3 emissive = lerp(_Color.rgb,_Color3.rgb,max(_Tex4_var.a,node_528));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
