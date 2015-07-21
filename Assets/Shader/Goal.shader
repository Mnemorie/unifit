// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-1431-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32110,y:32569,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9856,x:32110,y:32755,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_9856,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:080591fda7eb7d24cbe458aafca0b041,ntxv:0,isnm:False|UVIN-9666-OUT;n:type:ShaderForge.SFN_Time,id:5446,x:31752,y:32911,varname:node_5446,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:9413,x:31737,y:32577,varname:node_9413,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1431,x:32439,y:32704,varname:node_1431,prsc:2|A-7241-RGB,B-9856-RGB,C-7241-A;n:type:ShaderForge.SFN_Slider,id:7694,x:31595,y:32836,ptovrint:False,ptlb:Scrolling Speed,ptin:_ScrollingSpeed,varname:node_7694,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2051282,max:1;n:type:ShaderForge.SFN_Multiply,id:6027,x:31919,y:32836,varname:node_6027,prsc:2|A-7694-OUT,B-5446-T,C-1522-OUT;n:type:ShaderForge.SFN_Add,id:9666,x:31919,y:32691,varname:node_9666,prsc:2|A-9413-UVOUT,B-6027-OUT;n:type:ShaderForge.SFN_Sin,id:687,x:31960,y:33132,varname:node_687,prsc:2|IN-1644-OUT;n:type:ShaderForge.SFN_Slider,id:6713,x:31389,y:33164,ptovrint:False,ptlb:Scrolling Direction,ptin:_ScrollingDirection,varname:node_6713,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Cos,id:1475,x:31960,y:33288,varname:node_1475,prsc:2|IN-1644-OUT;n:type:ShaderForge.SFN_Append,id:1522,x:32158,y:33174,varname:node_1522,prsc:2|A-687-OUT,B-1475-OUT;n:type:ShaderForge.SFN_Tau,id:2332,x:31527,y:33311,varname:node_2332,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1644,x:31767,y:33239,varname:node_1644,prsc:2|A-6713-OUT,B-2332-OUT;proporder:7241-9856-7694-6713;pass:END;sub:END;*/

Shader "Shader Forge/ScrollingTexture" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Texture ("Texture", 2D) = "white" {}
        _ScrollingSpeed ("Scrolling Speed", Range(0, 1)) = 0.2051282
        _ScrollingDirection ("Scrolling Direction", Range(0, 1)) = 0.8
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _ScrollingSpeed;
            uniform float _ScrollingDirection;
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
                float4 node_5446 = _Time + _TimeEditor;
                float node_2332 = 6.28318530718;
                float node_1644 = (_ScrollingDirection*node_2332);
                float2 node_1522 = float2(sin(node_1644),cos(node_1644));
                float2 node_9666 = (i.uv0+(_ScrollingSpeed*node_5446.g*node_1522));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_9666, _Texture));
                float3 emissive = (_Color.rgb*_Texture_var.rgb*_Color.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}