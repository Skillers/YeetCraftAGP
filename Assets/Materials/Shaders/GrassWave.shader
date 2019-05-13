Shader "Unlit/GrassWave"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_HeightCutoff("Height Cutoff", float) = 1.0
		_WaveSpeed("Wave Speed", float) = 1.0
        _WaveAmp("Wave Amp", float) = 1.0
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
			float _HeightCutoff;
			float _WaveSpeed;
			float _WaveAmp;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
				float heightFactor = v.vertex.y > _HeightCutoff;
				float samplePos = (worldPos.x - v.vertex.x)/2;
				o.vertex.x += cos(_Time.x *_WaveSpeed + samplePos)*_WaveAmp * heightFactor;
				o.vertex.y += (sin(_Time.x* 0.5 *_WaveSpeed + samplePos)*_WaveAmp * heightFactor)/2;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
