// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/ScreenCutoutShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off
		Cull Back
		ZWrite On
		ZTest Less
		
		Fog{ Mode Off }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"


			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
			};

			struct v2f
			{
				//float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;

				UNITY_VERTEX_OUTPUT_STEREO //Insert
			};

			v2f vert (appdata v)
			{
				v2f o;

				UNITY_SETUP_INSTANCE_ID(v); //Insert
    			UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
    			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);
				return o;
			}
			
			sampler2D _MainTex;
			float4 _MainTex_ST;

			//UNITY_DECLARE_SCREENSPACE_TEXTURE(_MainTex); //Insert

			fixed4 frag (v2f i) : SV_Target
			{

				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //Insert

				i.screenPos /= i.screenPos.w;
				//fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y));
				fixed4 col = tex2D(_MainTex, UnityStereoScreenSpaceUVAdjust(i.screenPos, _MainTex_ST));

				//fixed4 col = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_MainTex, i.screenPos); //Insert//
				return col;
			}


/*
			struct appdata
			{
			    float4 vertex : POSITION;
			    float2 uv : TEXCOORD0;

			    UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
			};

			//v2f output struct

			struct v2f
			{
			
			    float2 uv : TEXCOORD0;
			    float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;

			    UNITY_VERTEX_OUTPUT_STEREO //Insert
			};

			v2f vert (appdata v)
			{
			    v2f o;

			    UNITY_SETUP_INSTANCE_ID(v); //Insert
			    UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
			    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert

			    o.vertex = UnityObjectToClipPos(v.vertex);
			    o.uv = v.uv;
			    return o;
			}

			UNITY_DECLARE_SCREENSPACE_TEXTURE(_MainTex); //Insert

			fixed4 frag (v2f i) : SV_Target
			{
			    UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //Insert

				i.screenPos /= i.screenPos.w;
			    fixed4 col = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_MainTex, i.screenPos); //Insert

			    return col;
			}

			*/
			ENDCG
		}
	}
}
