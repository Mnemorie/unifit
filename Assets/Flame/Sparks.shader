// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7241-RGB,clip-8453-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32083,y:32708,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4016,x:31957,y:32884,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_4016,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1519-OUT;n:type:ShaderForge.SFN_Step,id:8453,x:32487,y:32973,varname:node_8453,prsc:2|A-4429-OUT,B-3616-OUT;n:type:ShaderForge.SFN_Desaturate,id:3616,x:32154,y:32924,varname:node_3616,prsc:2|COL-4016-RGB;n:type:ShaderForge.SFN_Vector1,id:4429,x:32319,y:33098,varname:node_4429,prsc:2,v1:0.5;n:type:ShaderForge.SFN_TexCoord,id:9443,x:31440,y:32801,varname:node_9443,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:7957,x:31283,y:33026,ptovrint:False,ptlb:TilingV,ptin:_TilingV,varname:node_7957,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Append,id:1519,x:31808,y:32838,varname:node_1519,prsc:2|A-9443-U,B-1099-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1099,x:31644,y:32901,varname:node_1099,prsc:2|IN-9443-V,IMIN-158-OUT,IMAX-7957-OUT,OMIN-158-OUT,OMAX-6158-OUT;n:type:ShaderForge.SFN_Vector1,id:158,x:31440,y:32948,varname:node_158,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6158,x:31440,y:33106,varname:node_6158,prsc:2,v1:1;proporder:7241-4016-7957;pass:END;sub:END;*/

Shader "Shader Forge/Sparks" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Texture ("Texture", 2D) = "white" {}
        _TilingV ("TilingV", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _TilingV;
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
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_158 = 0.0;
                float2 node_1519 = float2(i.uv0.r,(node_158 + ( (i.uv0.g - node_158) * (1.0 - node_158) ) / (_TilingV - node_158)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1519, _Texture));
                clip(step(0.5,dot(_Texture_var.rgb,float3(0.3,0.59,0.11))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _TilingV;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float node_158 = 0.0;
                float2 node_1519 = float2(i.uv0.r,(node_158 + ( (i.uv0.g - node_158) * (1.0 - node_158) ) / (_TilingV - node_158)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1519, _Texture));
                clip(step(0.5,dot(_Texture_var.rgb,float3(0.3,0.59,0.11))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
