// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4013,x:32844,y:32672,varname:node_4013,prsc:2|diff-157-OUT,emission-3849-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32034,y:32617,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector3,id:8217,x:31495,y:32771,varname:node_8217,prsc:2,v1:0,v2:-1,v3:0;n:type:ShaderForge.SFN_Dot,id:1692,x:31691,y:32700,varname:node_1692,prsc:2,dt:4|A-6808-OUT,B-8217-OUT;n:type:ShaderForge.SFN_NormalVector,id:6808,x:31495,y:32592,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:2797,x:32141,y:33507,ptovrint:False,ptlb:FresnelStrength,ptin:_FresnelStrength,varname:node_2797,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:7371,x:32034,y:32791,varname:node_7371,prsc:2|A-2821-OUT,B-3656-OUT;n:type:ShaderForge.SFN_Add,id:4204,x:32525,y:32794,varname:node_4204,prsc:2|A-7741-OUT,B-6977-OUT,C-7371-OUT,D-5809-OUT;n:type:ShaderForge.SFN_Dot,id:7312,x:31716,y:32510,varname:node_7312,prsc:2,dt:1|A-5593-OUT,B-6808-OUT;n:type:ShaderForge.SFN_Vector3,id:5593,x:31493,y:32470,varname:node_5593,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Cubemap,id:2861,x:31604,y:33288,ptovrint:False,ptlb:Cubemap,ptin:_Cubemap,varname:node_2861,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0|DIR-6146-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:4873,x:31296,y:33151,varname:node_4873,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6977,x:32278,y:33001,varname:node_6977,prsc:2|A-1304-RGB,B-2861-RGB,C-9848-OUT,D-3591-OUT;n:type:ShaderForge.SFN_Power,id:7741,x:32304,y:32416,varname:node_7741,prsc:2|VAL-7550-OUT,EXP-1117-OUT;n:type:ShaderForge.SFN_Vector1,id:1117,x:32304,y:32353,varname:node_1117,prsc:2,v1:0.5;n:type:ShaderForge.SFN_RemapRange,id:7792,x:31969,y:32415,varname:node_7792,prsc:2,frmn:0.5,frmx:1,tomn:0,tomx:1|IN-7312-OUT;n:type:ShaderForge.SFN_Clamp01,id:7550,x:32139,y:32415,varname:node_7550,prsc:2|IN-7792-OUT;n:type:ShaderForge.SFN_Power,id:2821,x:31866,y:32700,varname:node_2821,prsc:2|VAL-1692-OUT,EXP-9517-OUT;n:type:ShaderForge.SFN_Vector1,id:9517,x:31691,y:32844,varname:node_9517,prsc:2,v1:3;n:type:ShaderForge.SFN_Slider,id:1557,x:31581,y:33114,ptovrint:False,ptlb:ReflectionStrenght,ptin:_ReflectionStrenght,varname:node_1557,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Tex2d,id:197,x:32278,y:33161,ptovrint:False,ptlb:Cavity,ptin:_Cavity,varname:node_197,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3849,x:32654,y:32960,varname:node_3849,prsc:2|A-4204-OUT,B-197-RGB;n:type:ShaderForge.SFN_Multiply,id:157,x:32525,y:32640,varname:node_157,prsc:2|A-1304-RGB,B-197-RGB;n:type:ShaderForge.SFN_Fresnel,id:4378,x:32298,y:33359,varname:node_4378,prsc:2|EXP-3585-OUT;n:type:ShaderForge.SFN_Vector1,id:3656,x:31866,y:32825,varname:node_3656,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:5809,x:32481,y:33420,varname:node_5809,prsc:2|A-4378-OUT,B-2797-OUT;n:type:ShaderForge.SFN_Vector1,id:3585,x:32113,y:33375,varname:node_3585,prsc:2,v1:5;n:type:ShaderForge.SFN_Fresnel,id:3591,x:31738,y:32963,varname:node_3591,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9848,x:31953,y:33072,varname:node_9848,prsc:2|A-1557-OUT,B-1557-OUT;n:type:ShaderForge.SFN_Time,id:7466,x:30966,y:33643,varname:node_7466,prsc:2;n:type:ShaderForge.SFN_Sin,id:3165,x:31663,y:33502,varname:node_3165,prsc:2|IN-3254-OUT;n:type:ShaderForge.SFN_Cos,id:2791,x:31663,y:33631,varname:node_2791,prsc:2|IN-3254-OUT;n:type:ShaderForge.SFN_Sin,id:2133,x:31663,y:33771,varname:node_2133,prsc:2|IN-3254-OUT;n:type:ShaderForge.SFN_Append,id:4287,x:31881,y:33610,varname:node_4287,prsc:2|A-3165-OUT,B-2791-OUT,C-2133-OUT;n:type:ShaderForge.SFN_Frac,id:6101,x:31316,y:33618,varname:node_6101,prsc:2|IN-1346-OUT;n:type:ShaderForge.SFN_Add,id:6146,x:31422,y:33288,varname:node_6146,prsc:2|A-4873-OUT,B-4287-OUT;n:type:ShaderForge.SFN_Multiply,id:3254,x:31471,y:33618,varname:node_3254,prsc:2|A-6101-OUT,B-1701-OUT;n:type:ShaderForge.SFN_Tau,id:1701,x:31349,y:33760,varname:node_1701,prsc:2;n:type:ShaderForge.SFN_Slider,id:6172,x:30809,y:33576,ptovrint:False,ptlb:ReflectionSpeed,ptin:_ReflectionSpeed,varname:node_6172,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1346,x:31166,y:33618,varname:node_1346,prsc:2|A-6172-OUT,B-7466-TSL;proporder:1304-2797-2861-1557-197-6172;pass:END;sub:END;*/

Shader "Shader Forge/Gold" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _FresnelStrength ("FresnelStrength", Range(0, 1)) = 0
        _Cubemap ("Cubemap", Cube) = "_Skybox" {}
        _ReflectionStrenght ("ReflectionStrenght", Range(0, 2)) = 0
        _Cavity ("Cavity", 2D) = "white" {}
        _ReflectionSpeed ("ReflectionSpeed", Range(0, 1)) = 0
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _FresnelStrength;
            uniform samplerCUBE _Cubemap;
            uniform float _ReflectionStrenght;
            uniform sampler2D _Cavity; uniform float4 _Cavity_ST;
            uniform float _ReflectionSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Cavity_var = tex2D(_Cavity,TRANSFORM_TEX(i.uv0, _Cavity));
                float3 diffuseColor = (_Color.rgb*_Cavity_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_7466 = _Time + _TimeEditor;
                float node_3254 = (frac((_ReflectionSpeed*node_7466.r))*6.28318530718);
                float3 emissive = ((pow(saturate((max(0,dot(float3(0,1,0),i.normalDir))*2.0+-1.0)),0.5)+(_Color.rgb*texCUBE(_Cubemap,(viewReflectDirection+float3(sin(node_3254),cos(node_3254),sin(node_3254)))).rgb*(_ReflectionStrenght*_ReflectionStrenght)*(1.0-max(0,dot(normalDirection, viewDirection))))+(pow(0.5*dot(i.normalDir,float3(0,-1,0))+0.5,3.0)*0.2)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),5.0)*_FresnelStrength))*_Cavity_var.rgb);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _FresnelStrength;
            uniform samplerCUBE _Cubemap;
            uniform float _ReflectionStrenght;
            uniform sampler2D _Cavity; uniform float4 _Cavity_ST;
            uniform float _ReflectionSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Cavity_var = tex2D(_Cavity,TRANSFORM_TEX(i.uv0, _Cavity));
                float3 diffuseColor = (_Color.rgb*_Cavity_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
