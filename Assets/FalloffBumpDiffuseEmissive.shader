// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:1,fgcg:1,fgcb:1,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:33793,y:32719,varname:node_1,prsc:2|diff-55-OUT,spec-710-OUT,gloss-63-OUT,normal-2-RGB,emission-8209-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33829,y:32545,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:node_2474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:11,x:33168,y:32149,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3760,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:17,x:31611,y:33645,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_5725,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Color,id:23,x:32367,y:33724,ptovrint:False,ptlb:Emission Color,ptin:_EmissionColor,varname:node_5355,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.05,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:41,x:32979,y:31973,ptovrint:False,ptlb:Falloff Color,ptin:_FalloffColor,varname:node_513,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_NormalVector,id:51,x:32880,y:32329,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:53,x:33398,y:32040,varname:node_53,prsc:2|A-56-OUT,B-11-RGB;n:type:ShaderForge.SFN_Lerp,id:55,x:33398,y:32225,cmnt:Diffuse,varname:node_55,prsc:2|A-53-OUT,B-11-RGB,T-1630-OUT;n:type:ShaderForge.SFN_Multiply,id:56,x:33188,y:31973,varname:node_56,prsc:2|A-41-RGB,B-57-OUT;n:type:ShaderForge.SFN_Vector1,id:57,x:32979,y:32113,varname:node_57,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:63,x:32796,y:33029,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_7989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:79,x:31221,y:33847,ptovrint:False,ptlb:Range Min,ptin:_RangeMin,varname:node_654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.25,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:398,x:32045,y:33873,cmnt:Normalize range,varname:node_398,prsc:2|IN-9072-OUT,IMIN-6470-OUT,IMAX-2941-OUT,OMIN-399-OUT,OMAX-400-OUT;n:type:ShaderForge.SFN_Vector1,id:399,x:32045,y:33796,varname:node_399,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:400,x:32045,y:34043,varname:node_400,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:401,x:32195,y:33873,varname:node_401,prsc:2|IN-398-OUT;n:type:ShaderForge.SFN_Lerp,id:485,x:32933,y:33724,cmnt:Glow Color,varname:node_485,prsc:2|A-486-OUT,B-491-OUT,T-7501-OUT;n:type:ShaderForge.SFN_Multiply,id:486,x:32603,y:33724,varname:node_486,prsc:2|A-23-RGB,B-7501-OUT,C-487-OUT;n:type:ShaderForge.SFN_Vector1,id:487,x:32603,y:33669,varname:node_487,prsc:2,v1:2;n:type:ShaderForge.SFN_OneMinus,id:488,x:32603,y:33847,varname:node_488,prsc:2|IN-23-RGB;n:type:ShaderForge.SFN_OneMinus,id:489,x:32603,y:33988,varname:node_489,prsc:2|IN-7501-OUT;n:type:ShaderForge.SFN_Multiply,id:490,x:32783,y:33896,varname:node_490,prsc:2|A-487-OUT,B-488-OUT,C-489-OUT;n:type:ShaderForge.SFN_OneMinus,id:491,x:32933,y:33896,varname:node_491,prsc:2|IN-490-OUT;n:type:ShaderForge.SFN_Multiply,id:704,x:32961,y:32654,varname:node_704,prsc:2|A-1088-RGB,B-1106-OUT;n:type:ShaderForge.SFN_Desaturate,id:710,x:33143,y:32654,cmnt:Specular Gloss,varname:node_710,prsc:2|COL-704-OUT;n:type:ShaderForge.SFN_Multiply,id:1053,x:34174,y:33725,varname:node_1053,prsc:2|A-1071-OUT,B-1054-OUT;n:type:ShaderForge.SFN_Vector1,id:1054,x:34174,y:33846,varname:node_1054,prsc:2,v1:100;n:type:ShaderForge.SFN_Add,id:1055,x:34174,y:33580,cmnt:Add HDR to Color,varname:node_1055,prsc:2|A-1287-OUT,B-1053-OUT;n:type:ShaderForge.SFN_Power,id:1071,x:33998,y:33725,varname:node_1071,prsc:2|VAL-6659-OUT,EXP-1077-OUT;n:type:ShaderForge.SFN_Vector1,id:1077,x:33998,y:33846,varname:node_1077,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:1088,x:32718,y:32654,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_4231,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1106,x:32961,y:32857,varname:node_1106,prsc:2|A-7520-OUT,B-1107-OUT;n:type:ShaderForge.SFN_Vector1,id:1107,x:32796,y:32901,varname:node_1107,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:1115,x:31728,y:32994,ptovrint:False,ptlb:Distance,ptin:_Distance,varname:node_6899,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1121,x:32206,y:33150,varname:node_1121,prsc:2|IN-1115-R,IMIN-1122-OUT,IMAX-1123-OUT,OMIN-1126-OUT,OMAX-1125-OUT;n:type:ShaderForge.SFN_Vector1,id:1122,x:32206,y:33093,varname:node_1122,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1123,x:32206,y:33275,varname:node_1123,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:1124,x:31421,y:33205,ptovrint:False,ptlb:Range,ptin:_Range,varname:node_2314,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Add,id:1125,x:31958,y:33310,varname:node_1125,prsc:2|A-5906-OUT,B-1127-OUT;n:type:ShaderForge.SFN_Subtract,id:1126,x:31958,y:33150,varname:node_1126,prsc:2|A-5906-OUT,B-1127-OUT;n:type:ShaderForge.SFN_Vector1,id:1127,x:31728,y:33354,varname:node_1127,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:1133,x:32356,y:33150,cmnt:Distance map sample range,varname:node_1133,prsc:2|IN-1121-OUT;n:type:ShaderForge.SFN_Dot,id:1626,x:33054,y:32329,varname:node_1626,prsc:2,dt:4|A-51-OUT,B-1629-OUT;n:type:ShaderForge.SFN_Vector3,id:1629,x:33054,y:32475,varname:node_1629,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Power,id:1630,x:33217,y:32329,varname:node_1630,prsc:2|VAL-1626-OUT,EXP-1631-OUT;n:type:ShaderForge.SFN_Vector1,id:1631,x:33217,y:32457,varname:node_1631,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:4070,x:31728,y:33150,varname:node_4070,prsc:2,v1:1.25;n:type:ShaderForge.SFN_Multiply,id:5906,x:31728,y:33205,varname:node_5906,prsc:2|A-1124-OUT,B-4070-OUT;n:type:ShaderForge.SFN_Relay,id:7501,x:32426,y:33873,varname:node_7501,prsc:2|IN-401-OUT;n:type:ShaderForge.SFN_Relay,id:8209,x:33546,y:32818,varname:node_8209,prsc:2|IN-1055-OUT;n:type:ShaderForge.SFN_Vector1,id:8277,x:33634,y:33847,varname:node_8277,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:9562,x:33634,y:33725,varname:node_9562,prsc:2|A-1287-OUT,B-8277-OUT;n:type:ShaderForge.SFN_Max,id:6659,x:33818,y:33725,varname:node_6659,prsc:2|A-9562-OUT,B-7244-OUT;n:type:ShaderForge.SFN_Vector1,id:7244,x:33818,y:33847,varname:node_7244,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Code,id:8888,x:34304,y:32859,varname:node_8888,prsc:2,code:,output:2,fname:Function_node_8888,width:519,height:310;n:type:ShaderForge.SFN_Slider,id:8673,x:31221,y:33953,ptovrint:False,ptlb:Range Max,ptin:_RangeMax,varname:node_8673,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.75,max:1;n:type:ShaderForge.SFN_Max,id:2941,x:31611,y:33981,varname:node_2941,prsc:2|A-79-OUT,B-8673-OUT;n:type:ShaderForge.SFN_Min,id:6470,x:31611,y:33821,varname:node_6470,prsc:2|A-79-OUT,B-8673-OUT;n:type:ShaderForge.SFN_Relay,id:1287,x:33502,y:33580,varname:node_1287,prsc:2|IN-485-OUT;n:type:ShaderForge.SFN_Multiply,id:2316,x:32429,y:33275,varname:node_2316,prsc:2|A-1133-OUT,B-17-G,C-2501-OUT;n:type:ShaderForge.SFN_Add,id:9072,x:32604,y:33275,varname:node_9072,prsc:2|A-2316-OUT,B-17-R;n:type:ShaderForge.SFN_Slider,id:7520,x:32639,y:32835,ptovrint:False,ptlb:SpecularStrength,ptin:_SpecularStrength,varname:node_7520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Distance,id:7031,x:31185,y:33469,varname:node_7031,prsc:2|A-9053-XYZ,B-4593-XYZ;n:type:ShaderForge.SFN_ObjectPosition,id:9053,x:30973,y:33416,varname:node_9053,prsc:2;n:type:ShaderForge.SFN_FragmentPosition,id:4593,x:30973,y:33545,varname:node_4593,prsc:2;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:2501,x:31431,y:33469,varname:node_2501,prsc:2|IN-7031-OUT,IMIN-4116-OUT,IMAX-2739-OUT,OMIN-7856-OUT,OMAX-4116-OUT;n:type:ShaderForge.SFN_Vector1,id:4116,x:31185,y:33594,varname:node_4116,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:2739,x:30816,y:33346,ptovrint:False,ptlb:Distance Falloff,ptin:_DistanceFalloff,varname:node_2739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:7856,x:31185,y:33643,varname:node_7856,prsc:2,v1:1;proporder:2-11-41-1088-63-7520-23-17-1115-1124-79-8673-2739;pass:END;sub:END;*/

Shader "Shader Forge/FalloffBumpDiffuseSpecularEmissive" {
    Properties {
        _Normals ("Normals", 2D) = "bump" {}
        _Diffuse ("Diffuse", 2D) = "white" {}
        _FalloffColor ("Falloff Color", Color) = (0,0,0,1)
        _Specular ("Specular", 2D) = "black" {}
        _Gloss ("Gloss", Range(0, 1)) = 0
        _SpecularStrength ("SpecularStrength", Range(0, 1)) = 0
        _EmissionColor ("Emission Color", Color) = (1,0.05,0,1)
        _Emission ("Emission", 2D) = "black" {}
        _Distance ("Distance", 2D) = "gray" {}
        _Range ("Range", Range(0, 1)) = 0.1
        _RangeMin ("Range Min", Range(0, 1)) = 0.25
        _RangeMax ("Range Max", Range(0, 1)) = 0.75
        _DistanceFalloff ("Distance Falloff", Range(0, 1)) = 0
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
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform float4 _EmissionColor;
            uniform float4 _FalloffColor;
            uniform float _Gloss;
            uniform float _RangeMin;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Distance; uniform float4 _Distance_ST;
            uniform float _Range;
            uniform float _RangeMax;
            uniform float _SpecularStrength;
            uniform float _DistanceFalloff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float node_710 = dot((_Specular_var.rgb*(_SpecularStrength*2.0)),float3(0.3,0.59,0.11)); // Specular Gloss
                float3 specularColor = float3(node_710,node_710,node_710);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = lerp(((_FalloffColor.rgb*0.5)*_Diffuse_var.rgb),_Diffuse_var.rgb,pow(0.5*dot(normalDirection,float3(0,1,0))+0.5,0.5));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 _Distance_var = tex2D(_Distance,TRANSFORM_TEX(i.uv0, _Distance));
                float node_1122 = 0.0;
                float node_5906 = (_Range*1.25);
                float node_1127 = 0.5;
                float node_1126 = (node_5906-node_1127);
                float4 _Emission_var = tex2D(_Emission,TRANSFORM_TEX(i.uv0, _Emission));
                float node_4116 = 0.0;
                float node_7856 = 1.0;
                float node_6470 = min(_RangeMin,_RangeMax);
                float node_399 = 0.0;
                float node_7501 = saturate((node_399 + ( (((saturate((node_1126 + ( (_Distance_var.r - node_1122) * ((node_5906+node_1127) - node_1126) ) / (1.0 - node_1122)))*_Emission_var.g*(node_7856 + ( (distance(objPos.rgb,i.posWorld.rgb) - node_4116) * (node_4116 - node_7856) ) / (_DistanceFalloff - node_4116)))+_Emission_var.r) - node_6470) * (1.0 - node_399) ) / (max(_RangeMin,_RangeMax) - node_6470)));
                float node_487 = 2.0;
                float3 node_1287 = lerp((_EmissionColor.rgb*node_7501*node_487),(1.0 - (node_487*(1.0 - _EmissionColor.rgb)*(1.0 - node_7501))),node_7501);
                float3 emissive = (node_1287+(pow(max((node_1287+(-1.0)),0.01),2.0)*100.0));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform float4 _EmissionColor;
            uniform float4 _FalloffColor;
            uniform float _Gloss;
            uniform float _RangeMin;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Distance; uniform float4 _Distance_ST;
            uniform float _Range;
            uniform float _RangeMax;
            uniform float _SpecularStrength;
            uniform float _DistanceFalloff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float node_710 = dot((_Specular_var.rgb*(_SpecularStrength*2.0)),float3(0.3,0.59,0.11)); // Specular Gloss
                float3 specularColor = float3(node_710,node_710,node_710);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = lerp(((_FalloffColor.rgb*0.5)*_Diffuse_var.rgb),_Diffuse_var.rgb,pow(0.5*dot(normalDirection,float3(0,1,0))+0.5,0.5));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
