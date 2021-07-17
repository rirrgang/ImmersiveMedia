Shader "Custom/DrunkyShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DistortionAmplitude ("Distortion Aplitude", Float) = 100
        _DistortionSpeed ("Distortion Speed", Float) = 1
        _DistortionIntensity ("Distortion Intensity", Float) = 100
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float _DistortionAmplitude;
            float _DistortionSpeed;
            float _DistortionIntensity;

            fixed4 frag (v2f i) : SV_Target
            {
                
                //Distort Image
                fixed4 col = tex2D(_MainTex, i.uv 
                    + float2(0, sin( i.vertex.y/_DistortionAmplitude + _Time[1]/_DistortionSpeed) / _DistortionIntensity) 
                    + float2(0, sin( i.vertex.x/_DistortionAmplitude + _Time[1]/_DistortionSpeed) / _DistortionIntensity));

                //Invert colors
                //col = 1 - col;

                return col;
            }
            ENDCG
        }
    }
}
