// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:2,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:333,x:34613,y:33158,varname:node_333,prsc:2|diff-7142-OUT,spec-2755-OUT,gloss-6432-OUT,normal-7415-OUT,alpha-995-OUT,refract-9213-OUT;n:type:ShaderForge.SFN_Code,id:2695,x:32090,y:32623,varname:node_2695,prsc:2,code:dgBpAGUAdwBEAGkAcgAgAD0AIABuAG8AcgBtAGEAbABpAHoAZQAoAHYAaQBlAHcARABpAHIAKQA7AAoAZgBsAG8AYQB0ADMAIABwACAAPQAgAGYAbABvAGEAdAAzACgAVQBWACwAIAAwACkAOwAKAGYAbABvAGEAdAAzACAAbgBlAHcAVgBpAGUAdwAgAD0AIABuAG8AcgBtAGEAbABpAHoAZQAoAHYAaQBlAHcARABpAHIAIAAqACAALQAxACkAOwAKAG4AZQB3AFYAaQBlAHcALgB6ACAAPQAgAGEAYgBzACgAbgBlAHcAVgBpAGUAdwAuAHoAKQA7AAoACgBmAGwAbwBhAHQAIABkAGUAcAB0AGgAQgBpAGEAcwAgAD0AIAAxAC4AMAAgAC0AIABuAGUAdwBWAGkAZQB3AC4AegA7AAoAZABlAHAAdABoAEIAaQBhAHMAIAAqAD0AIABkAGUAcAB0AGgAQgBpAGEAcwA7AAoAZABlAHAAdABoAEIAaQBhAHMAIAAqAD0AIABkAGUAcAB0AGgAQgBpAGEAcwA7AAoAZABlAHAAdABoAEIAaQBhAHMAIAA9ACAAMQAuADAAIAAtACAAZABlAHAAdABoAEIAaQBhAHMAIAAqACAAZABlAHAAdABoAEIAaQBhAHMAOwAKAAoAbgBlAHcAVgBpAGUAdwAuAHgAeQAgACoAPQAgAGQAZQBwAHQAaABCAGkAYQBzADsACgBuAGUAdwBWAGkAZQB3AC4AeAB5ACAAKgA9ACAARABlAHAAdABoADsACgAKAGMAbwBuAHMAdAAgAGkAbgB0ACAAYgBpAG4AYQByAHkAUwBlAGEAcgBjAGgAUwB0AGUAcABzACAAPQAgADEAMAA7AAoACgBuAGUAdwBWAGkAZQB3ACAALwA9ACAAbgBlAHcAVgBpAGUAdwAuAHoAIAAqACAAbABpAG4AZQBhAHIAUwBlAGEAcgBjAGgAUwB0AGUAcABzADsACgAKAC8ALwBwAHIAbwBkAHUAYwBlAHMAIABkAGUAcAB0AGgACgBpAG4AdAAgAGkAOwAKAGYAbwByACgAIABpAD0AMAA7ACAAaQA8AGwAaQBuAGUAYQByAFMAZQBhAHIAYwBoAFMAdABlAHAAcwA7ACAAaQArACsAIAApAHsACgBmAGwAbwBhAHQAIAB0AGUAeAAgAD0AIAB0AGUAeAAyAEQAKABIAGUAaQBnAGgAdABNAGEAcAAsACAAcAAuAHgAeQApAC4AcgA7AAoAaQBmACAAKABwAC4AegA8AHQAZQB4ACkAIABwACsAPQBuAGUAdwBWAGkAZQB3ADsACgB9AAoACgBmAG8AcgAoACAAaQA9ADAAOwAgAGkAPABiAGkAbgBhAHIAeQBTAGUAYQByAGMAaABTAHQAZQBwAHMAOwAgAGkAKwArACAAKQB7AAoAbgBlAHcAVgBpAGUAdwAgACoAPQAgADAALgA1ADsACgBmAGwAbwBhAHQAIAB0AGUAeAAgAD0AIAB0AGUAeAAyAEQAKABIAGUAaQBnAGgAdABNAGEAcAAsACAAcAAuAHgAeQApAC4AcgA7AAoAaQBmACgAcAAuAHoAIAA8ACAAdABlAHgAKQAgAHAAKwA9ACAAbgBlAHcAVgBpAGUAdwA7AAoAZQBsAHMAZQAgAHAAIAAtAD0AIABuAGUAdwBWAGkAZQB3ADsACgB9AAoAcgBlAHQAdQByAG4AIABwADsA,output:2,fname:Relief,width:506,height:514,input:10,input:12,input:0,input:0,input:1,input_1_label:viewDir,input_2_label:HeightMap,input_3_label:Depth,input_4_label:linearSearchSteps,input_5_label:UV|A-3224-XYZ,B-8608-TEX,C-1388-OUT,D-1703-OUT,E-4814-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7405,x:31218,y:32937,varname:node_7405,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:1703,x:31802,y:32855,ptovrint:False,ptlb:Quality,ptin:_Quality,varname:_Quality,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:60;n:type:ShaderForge.SFN_ValueProperty,id:134,x:31450,y:32680,ptovrint:False,ptlb:Parallax,ptin:_Parallax,varname:_Parallax,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:8608,x:31727,y:32596,ptovrint:False,ptlb:Parallax Map,ptin:_ParallaxMap,varname:_ParallaxMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Transform,id:3224,x:31802,y:32391,varname:node_3224,prsc:2,tffrom:0,tfto:2|IN-2803-OUT;n:type:ShaderForge.SFN_ViewVector,id:2803,x:31621,y:32391,varname:node_2803,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:3086,x:32707,y:32648,varname:node_3086,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2695-OUT;n:type:ShaderForge.SFN_Tex2d,id:8144,x:32889,y:32821,varname:node_8144,prsc:2,ntxv:0,isnm:False|UVIN-3444-UVOUT,TEX-5560-TEX;n:type:ShaderForge.SFN_Negate,id:1388,x:31958,y:32779,varname:node_1388,prsc:2|IN-2416-OUT;n:type:ShaderForge.SFN_Multiply,id:8300,x:31698,y:33093,varname:node_8300,prsc:2|A-8352-OUT,B-2114-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2114,x:31510,y:33271,ptovrint:False,ptlb:Master Tiling,ptin:_MasterTiling,varname:_MasterTiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:8352,x:31402,y:33072,ptovrint:False,ptlb:WorldUV,ptin:_WorldUV,varname:_WorldUV,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7405-UVOUT,B-9363-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9363,x:31218,y:33128,varname:node_9363,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-4558-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:4558,x:31012,y:33054,varname:node_4558,prsc:2;n:type:ShaderForge.SFN_Panner,id:1920,x:32275,y:33288,varname:node_1920,prsc:2,spu:1,spv:1|UVIN-3086-OUT,DIST-1463-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5638,x:31328,y:33458,ptovrint:False,ptlb:Velocity main,ptin:_Velocitymain,varname:_Velocitymain,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5273,x:31469,y:33529,varname:node_5273,prsc:2|A-5638-OUT,B-3285-TSL;n:type:ShaderForge.SFN_Time,id:3285,x:31014,y:33417,varname:node_3285,prsc:2;n:type:ShaderForge.SFN_Panner,id:3444,x:32707,y:32839,varname:node_3444,prsc:2,spu:1,spv:1|UVIN-3086-OUT,DIST-5273-OUT;n:type:ShaderForge.SFN_Tex2d,id:1231,x:32718,y:33437,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1178-OUT;n:type:ShaderForge.SFN_Tex2d,id:3845,x:32903,y:33020,varname:node_3845,prsc:2,ntxv:0,isnm:False|UVIN-4666-OUT,TEX-5560-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5560,x:32654,y:33120,ptovrint:False,ptlb:Main Tex,ptin:_MainTex,varname:_MainTex,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:3005,x:33545,y:32908,varname:node_3005,prsc:2|A-8144-RGB,B-3845-RGB,T-1231-A;n:type:ShaderForge.SFN_Multiply,id:4666,x:32565,y:33277,varname:node_4666,prsc:2|A-1920-UVOUT,B-2326-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2326,x:32356,y:33454,ptovrint:False,ptlb:Second Tiling,ptin:_SecondTiling,varname:_SecondTiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Panner,id:9310,x:32237,y:33567,varname:node_9310,prsc:2,spu:1,spv:1|UVIN-4814-UVOUT,DIST-4373-OUT;n:type:ShaderForge.SFN_Sign,id:3601,x:32050,y:33677,varname:node_3601,prsc:2|IN-4373-OUT;n:type:ShaderForge.SFN_Multiply,id:1178,x:32505,y:33617,varname:node_1178,prsc:2|A-274-OUT,B-9310-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:274,x:32237,y:33853,ptovrint:False,ptlb:Noise Tiling,ptin:_NoiseTiling,varname:_NoiseTiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:1463,x:31491,y:33737,varname:node_1463,prsc:2|A-3285-TSL,B-6304-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6304,x:31253,y:33805,ptovrint:False,ptlb:Velocity second,ptin:_Velocitysecond,varname:_Velocitysecond,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4373,x:31848,y:33769,varname:node_4373,prsc:2|A-3285-TSL,B-8589-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8589,x:31695,y:33938,ptovrint:False,ptlb:Velocity noise,ptin:_Velocitynoise,varname:_Velocitynoise,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:7016,x:31610,y:32934,varname:node_7016,prsc:2|A-134-OUT,B-4408-OUT;n:type:ShaderForge.SFN_Sin,id:7908,x:31155,y:32791,varname:node_7908,prsc:2|IN-3285-TTR;n:type:ShaderForge.SFN_Add,id:2416,x:31828,y:32934,varname:node_2416,prsc:2|A-7016-OUT,B-134-OUT;n:type:ShaderForge.SFN_Vector1,id:9780,x:31420,y:32947,varname:node_9780,prsc:2,v1:0.1;n:type:ShaderForge.SFN_RemapRange,id:4408,x:31392,y:32759,varname:node_4408,prsc:2,frmn:-1,frmx:1,tomn:0.5,tomx:1.5|IN-7908-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5424,x:32791,y:33736,ptovrint:False,ptlb:Bump Map,ptin:_BumpMap,varname:_BumpMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3918,x:33069,y:33412,varname:node_3918,prsc:2,ntxv:0,isnm:False|UVIN-3444-UVOUT,TEX-5424-TEX;n:type:ShaderForge.SFN_Tex2d,id:2222,x:33069,y:33549,varname:node_2222,prsc:2,ntxv:0,isnm:False|UVIN-4666-OUT,TEX-5424-TEX;n:type:ShaderForge.SFN_Lerp,id:7415,x:33251,y:33487,varname:node_7415,prsc:2|A-3918-RGB,B-2222-RGB,T-1231-A;n:type:ShaderForge.SFN_Multiply,id:7804,x:34154,y:32927,varname:node_7804,prsc:2|A-3005-OUT,B-9184-OUT;n:type:ShaderForge.SFN_Color,id:7816,x:33631,y:32741,ptovrint:False,ptlb:Water Color,ptin:_WaterColor,varname:_WaterColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:7530,x:33154,y:33218,varname:node_7530,prsc:2|A-8144-A,B-3845-A,T-1231-A;n:type:ShaderForge.SFN_ValueProperty,id:9156,x:33297,y:33392,ptovrint:False,ptlb:Transparent Value,ptin:_TransparentValue,varname:_TransparentValue,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:2152,x:33886,y:33182,ptovrint:False,ptlb:Invert Opacity,ptin:_InvertOpacity,varname:_InvertOpacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7530-OUT,B-1337-OUT;n:type:ShaderForge.SFN_Depth,id:5543,x:33279,y:33017,varname:node_5543,prsc:2;n:type:ShaderForge.SFN_Multiply,id:425,x:33489,y:33057,varname:node_425,prsc:2|A-5543-OUT,B-6544-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6544,x:33279,y:33161,ptovrint:False,ptlb:Depth OP,ptin:_DepthOP,varname:_DepthOP,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:7651,x:33716,y:33512,ptovrint:False,ptlb:Metalness,ptin:_Metalness,varname:_Metalness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4937,x:34064,y:33172,varname:node_4937,prsc:2|A-7530-OUT,B-7651-OUT,C-9184-OUT;n:type:ShaderForge.SFN_Slider,id:6432,x:33424,y:33591,ptovrint:False,ptlb:Smoothness,ptin:_Smoothness,varname:_Smoothness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Clamp01,id:995,x:34334,y:33391,varname:node_995,prsc:2|IN-7364-OUT;n:type:ShaderForge.SFN_Panner,id:4814,x:31895,y:33144,varname:node_4814,prsc:2,spu:1,spv:1|UVIN-8300-OUT,DIST-9293-OUT;n:type:ShaderForge.SFN_ValueProperty,id:386,x:31591,y:33359,ptovrint:False,ptlb:Parallax Velocity,ptin:_ParallaxVelocity,varname:_ParallaxVelocity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:9293,x:31755,y:33359,varname:node_9293,prsc:2|A-386-OUT,B-3285-TSL;n:type:ShaderForge.SFN_Negate,id:7434,x:33489,y:33296,varname:node_7434,prsc:2|IN-7530-OUT;n:type:ShaderForge.SFN_Clamp01,id:1337,x:33683,y:33296,varname:node_1337,prsc:2|IN-7434-OUT;n:type:ShaderForge.SFN_Multiply,id:7364,x:34131,y:33365,varname:node_7364,prsc:2|A-2152-OUT,B-9156-OUT,C-425-OUT;n:type:ShaderForge.SFN_Color,id:4244,x:33631,y:32577,ptovrint:False,ptlb:Far Color,ptin:_FarColor,varname:_FarColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:9184,x:33886,y:32966,varname:node_9184,prsc:2|A-7816-RGB,B-4244-RGB,T-2466-OUT;n:type:ShaderForge.SFN_Vector3,id:8809,x:34246,y:33126,varname:node_8809,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Min,id:7142,x:34363,y:32919,varname:node_7142,prsc:2|A-7804-OUT,B-8809-OUT;n:type:ShaderForge.SFN_Clamp01,id:2755,x:34246,y:33223,varname:node_2755,prsc:2|IN-4937-OUT;n:type:ShaderForge.SFN_Clamp01,id:2466,x:33715,y:33081,varname:node_2466,prsc:2|IN-425-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2668,x:34041,y:33635,varname:node_2668,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8461-RGB;n:type:ShaderForge.SFN_Tex2d,id:8461,x:33074,y:33750,varname:node_8461,prsc:2,ntxv:0,isnm:False|UVIN-4814-UVOUT,TEX-5424-TEX;n:type:ShaderForge.SFN_Multiply,id:9213,x:34258,y:33651,varname:node_9213,prsc:2|A-2668-OUT,B-6829-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6829,x:34112,y:33845,ptovrint:False,ptlb:Refract,ptin:_Refract,varname:_Refract,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7816-4244-5560-2114-2326-8352-8608-134-1703-386-5638-6304-1231-274-8589-5424-9156-2152-6544-7651-6432-6829;pass:END;sub:END;*/

Shader "DLNK Shaders/Complex/OldWaterMoving" {
    Properties {
        _WaterColor ("Water Color", Color) = (0.5,0.5,0.5,1)
        _FarColor ("Far Color", Color) = (0.5,0.5,0.5,1)
        _MainTex ("Main Tex", 2D) = "white" {}
        _MasterTiling ("Master Tiling", Float ) = 1
        _SecondTiling ("Second Tiling", Float ) = 1
        [MaterialToggle] _WorldUV ("WorldUV", Float ) = 0
        _ParallaxMap ("Parallax Map", 2D) = "white" {}
        _Parallax ("Parallax", Float ) = 0
        _Quality ("Quality", Float ) = 60
        _ParallaxVelocity ("Parallax Velocity", Float ) = 0
        _Velocitymain ("Velocity main", Float ) = 0
        _Velocitysecond ("Velocity second", Float ) = 0
        _Noise ("Noise", 2D) = "white" {}
        _NoiseTiling ("Noise Tiling", Float ) = 1
        _Velocitynoise ("Velocity noise", Float ) = 0
        _BumpMap ("Bump Map", 2D) = "bump" {}
        _TransparentValue ("Transparent Value", Float ) = 0
        [MaterialToggle] _InvertOpacity ("Invert Opacity", Float ) = 0
        _DepthOP ("Depth OP", Float ) = 0
        _Metalness ("Metalness", Float ) = 0
        _Smoothness ("Smoothness", Range(0, 3)) = 0
        _Refract ("Refract", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            float3 Relief( fixed3 viewDir , sampler2D HeightMap , float Depth , float linearSearchSteps , float2 UV ){
            viewDir = normalize(viewDir);
            float3 p = float3(UV, 0);
            float3 newView = normalize(viewDir * -1);
            newView.z = abs(newView.z);
            
            float depthBias = 1.0 - newView.z;
            depthBias *= depthBias;
            depthBias *= depthBias;
            depthBias = 1.0 - depthBias * depthBias;
            
            newView.xy *= depthBias;
            newView.xy *= Depth;
            
            const int binarySearchSteps = 10;
            
            newView /= newView.z * linearSearchSteps;
            
            //produces depth
            int i;
            for( i=0; i<linearSearchSteps; i++ ){
            float tex = tex2D(HeightMap, p.xy).r;
            if (p.z<tex) p+=newView;
            }
            
            for( i=0; i<binarySearchSteps; i++ ){
            newView *= 0.5;
            float tex = tex2D(HeightMap, p.xy).r;
            if(p.z < tex) p+= newView;
            else p -= newView;
            }
            return p;
            }
            
            uniform float _Quality;
            uniform float _Parallax;
            uniform sampler2D _ParallaxMap; uniform float4 _ParallaxMap_ST;
            uniform float _MasterTiling;
            uniform fixed _WorldUV;
            uniform float _Velocitymain;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _SecondTiling;
            uniform float _NoiseTiling;
            uniform float _Velocitysecond;
            uniform float _Velocitynoise;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float4 _WaterColor;
            uniform float _TransparentValue;
            uniform fixed _InvertOpacity;
            uniform float _DepthOP;
            uniform float _Metalness;
            uniform float _Smoothness;
            uniform float _ParallaxVelocity;
            uniform float4 _FarColor;
            uniform float _Refract;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_3285 = _Time;
                float2 node_4814 = ((lerp( i.uv0, i.posWorld.rgb.rb, _WorldUV )*_MasterTiling)+(_ParallaxVelocity*node_3285.r)*float2(1,1));
                float2 node_3086 = Relief( mul( tangentTransform, viewDirection ).xyz.rgb , _ParallaxMap , (-1*((_Parallax*(sin(node_3285.a)*0.5+1.0))+_Parallax)) , _Quality , node_4814 ).rg;
                float2 node_3444 = (node_3086+(_Velocitymain*node_3285.r)*float2(1,1));
                float3 node_3918 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_3444, _BumpMap)));
                float2 node_4666 = ((node_3086+(node_3285.r*_Velocitysecond)*float2(1,1))*_SecondTiling);
                float3 node_2222 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_4666, _BumpMap)));
                float node_4373 = (node_3285.r*_Velocitynoise);
                float2 node_1178 = (_NoiseTiling*(node_4814+node_4373*float2(1,1)));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_1178, _Noise));
                float3 normalLocal = lerp(node_3918.rgb,node_2222.rgb,_Noise_var.a);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 node_8461 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_4814, _BumpMap)));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (node_8461.rgb.rg*_Refract);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Smoothness;
                float perceptualRoughness = 1.0 - _Smoothness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 node_8144 = tex2D(_MainTex,TRANSFORM_TEX(node_3444, _MainTex));
                float4 node_3845 = tex2D(_MainTex,TRANSFORM_TEX(node_4666, _MainTex));
                float node_7530 = lerp(node_8144.a,node_3845.a,_Noise_var.a);
                float node_425 = (partZ*_DepthOP);
                float3 node_9184 = lerp(_WaterColor.rgb,_FarColor.rgb,saturate(node_425));
                float3 specularColor = saturate((node_7530*_Metalness*node_9184)).r;
                float specularMonochrome;
                float3 diffuseColor = min((lerp(node_8144.rgb,node_3845.rgb,_Noise_var.a)*node_9184),float3(1,1,1)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(lerp(sceneColor.rgb, finalColor,saturate((lerp( node_7530, saturate((-1*node_7530)), _InvertOpacity )*_TransparentValue*node_425))),1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            float3 Relief( fixed3 viewDir , sampler2D HeightMap , float Depth , float linearSearchSteps , float2 UV ){
            viewDir = normalize(viewDir);
            float3 p = float3(UV, 0);
            float3 newView = normalize(viewDir * -1);
            newView.z = abs(newView.z);
            
            float depthBias = 1.0 - newView.z;
            depthBias *= depthBias;
            depthBias *= depthBias;
            depthBias = 1.0 - depthBias * depthBias;
            
            newView.xy *= depthBias;
            newView.xy *= Depth;
            
            const int binarySearchSteps = 10;
            
            newView /= newView.z * linearSearchSteps;
            
            //produces depth
            int i;
            for( i=0; i<linearSearchSteps; i++ ){
            float tex = tex2D(HeightMap, p.xy).r;
            if (p.z<tex) p+=newView;
            }
            
            for( i=0; i<binarySearchSteps; i++ ){
            newView *= 0.5;
            float tex = tex2D(HeightMap, p.xy).r;
            if(p.z < tex) p+= newView;
            else p -= newView;
            }
            return p;
            }
            
            uniform float _Quality;
            uniform float _Parallax;
            uniform sampler2D _ParallaxMap; uniform float4 _ParallaxMap_ST;
            uniform float _MasterTiling;
            uniform fixed _WorldUV;
            uniform float _Velocitymain;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _SecondTiling;
            uniform float _NoiseTiling;
            uniform float _Velocitysecond;
            uniform float _Velocitynoise;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float4 _WaterColor;
            uniform float _TransparentValue;
            uniform fixed _InvertOpacity;
            uniform float _DepthOP;
            uniform float _Metalness;
            uniform float _Smoothness;
            uniform float _ParallaxVelocity;
            uniform float4 _FarColor;
            uniform float _Refract;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_3285 = _Time;
                float2 node_4814 = ((lerp( i.uv0, i.posWorld.rgb.rb, _WorldUV )*_MasterTiling)+(_ParallaxVelocity*node_3285.r)*float2(1,1));
                float2 node_3086 = Relief( mul( tangentTransform, viewDirection ).xyz.rgb , _ParallaxMap , (-1*((_Parallax*(sin(node_3285.a)*0.5+1.0))+_Parallax)) , _Quality , node_4814 ).rg;
                float2 node_3444 = (node_3086+(_Velocitymain*node_3285.r)*float2(1,1));
                float3 node_3918 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_3444, _BumpMap)));
                float2 node_4666 = ((node_3086+(node_3285.r*_Velocitysecond)*float2(1,1))*_SecondTiling);
                float3 node_2222 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_4666, _BumpMap)));
                float node_4373 = (node_3285.r*_Velocitynoise);
                float2 node_1178 = (_NoiseTiling*(node_4814+node_4373*float2(1,1)));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_1178, _Noise));
                float3 normalLocal = lerp(node_3918.rgb,node_2222.rgb,_Noise_var.a);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 node_8461 = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_4814, _BumpMap)));
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + (node_8461.rgb.rg*_Refract);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Smoothness;
                float perceptualRoughness = 1.0 - _Smoothness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 node_8144 = tex2D(_MainTex,TRANSFORM_TEX(node_3444, _MainTex));
                float4 node_3845 = tex2D(_MainTex,TRANSFORM_TEX(node_4666, _MainTex));
                float node_7530 = lerp(node_8144.a,node_3845.a,_Noise_var.a);
                float node_425 = (partZ*_DepthOP);
                float3 node_9184 = lerp(_WaterColor.rgb,_FarColor.rgb,saturate(node_425));
                float3 specularColor = saturate((node_7530*_Metalness*node_9184)).r;
                float specularMonochrome;
                float3 diffuseColor = min((lerp(node_8144.rgb,node_3845.rgb,_Noise_var.a)*node_9184),float3(1,1,1)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * saturate((lerp( node_7530, saturate((-1*node_7530)), _InvertOpacity )*_TransparentValue*node_425)),0);
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            float3 Relief( fixed3 viewDir , sampler2D HeightMap , float Depth , float linearSearchSteps , float2 UV ){
            viewDir = normalize(viewDir);
            float3 p = float3(UV, 0);
            float3 newView = normalize(viewDir * -1);
            newView.z = abs(newView.z);
            
            float depthBias = 1.0 - newView.z;
            depthBias *= depthBias;
            depthBias *= depthBias;
            depthBias = 1.0 - depthBias * depthBias;
            
            newView.xy *= depthBias;
            newView.xy *= Depth;
            
            const int binarySearchSteps = 10;
            
            newView /= newView.z * linearSearchSteps;
            
            //produces depth
            int i;
            for( i=0; i<linearSearchSteps; i++ ){
            float tex = tex2D(HeightMap, p.xy).r;
            if (p.z<tex) p+=newView;
            }
            
            for( i=0; i<binarySearchSteps; i++ ){
            newView *= 0.5;
            float tex = tex2D(HeightMap, p.xy).r;
            if(p.z < tex) p+= newView;
            else p -= newView;
            }
            return p;
            }
            
            uniform float _Quality;
            uniform float _Parallax;
            uniform sampler2D _ParallaxMap; uniform float4 _ParallaxMap_ST;
            uniform float _MasterTiling;
            uniform fixed _WorldUV;
            uniform float _Velocitymain;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _SecondTiling;
            uniform float _NoiseTiling;
            uniform float _Velocitysecond;
            uniform float _Velocitynoise;
            uniform float4 _WaterColor;
            uniform float _DepthOP;
            uniform float _Metalness;
            uniform float _Smoothness;
            uniform float _ParallaxVelocity;
            uniform float4 _FarColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 projPos : TEXCOORD7;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 node_3285 = _Time;
                float2 node_4814 = ((lerp( i.uv0, i.posWorld.rgb.rb, _WorldUV )*_MasterTiling)+(_ParallaxVelocity*node_3285.r)*float2(1,1));
                float2 node_3086 = Relief( mul( tangentTransform, viewDirection ).xyz.rgb , _ParallaxMap , (-1*((_Parallax*(sin(node_3285.a)*0.5+1.0))+_Parallax)) , _Quality , node_4814 ).rg;
                float2 node_3444 = (node_3086+(_Velocitymain*node_3285.r)*float2(1,1));
                float4 node_8144 = tex2D(_MainTex,TRANSFORM_TEX(node_3444, _MainTex));
                float2 node_4666 = ((node_3086+(node_3285.r*_Velocitysecond)*float2(1,1))*_SecondTiling);
                float4 node_3845 = tex2D(_MainTex,TRANSFORM_TEX(node_4666, _MainTex));
                float node_4373 = (node_3285.r*_Velocitynoise);
                float2 node_1178 = (_NoiseTiling*(node_4814+node_4373*float2(1,1)));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_1178, _Noise));
                float node_425 = (partZ*_DepthOP);
                float3 node_9184 = lerp(_WaterColor.rgb,_FarColor.rgb,saturate(node_425));
                float3 diffColor = min((lerp(node_8144.rgb,node_3845.rgb,_Noise_var.a)*node_9184),float3(1,1,1));
                float specularMonochrome;
                float3 specColor;
                float node_7530 = lerp(node_8144.a,node_3845.a,_Noise_var.a);
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, saturate((node_7530*_Metalness*node_9184)).r, specColor, specularMonochrome );
                float roughness = 1.0 - _Smoothness;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
