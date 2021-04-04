// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Demo_Flag/Flag"  // 旗帜飘动
{
	Properties
	{
		_MainTex("Main Tex", 2D) = "white" {}               	      //主纹理
	_FlagColor("Flag Color", Color) = (1, 1, 1, 1)        	      //旗子颜色
		_Frequency("Frequency", float) = 1                   	      //波动频率
		_AmplitudeStrength("Amplitude Strength", float) = 1           // 振幅强度
		_InvWaveLength("Inverse Wave Length", float) = 1             //波长的倒数（_InvWaveLength越小，波长越大）
		_Fold("Fold", Range(0.0, 2.0)) = 0.5                         //旗帜褶皱程度
	}
		SubShader
	{
		// Need to disable batching because of the vertex animation
		Tags{ "DisableBatching" = "True" "RenderType" = "Opaque" }

		Pass
	{
		Tags{ "LightMode" = "ForwardBase" }

		Cull Off

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		sampler2D _MainTex;
	float4 _MainTex_ST;
	float4 _FlagColor;
	float _Frequency;
	float _AmplitudeStrength;
	float _InvWaveLength;
	float _Fold;

	struct a2v
	{
		float4 vertex : POSITION;
		float4 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};

	v2f vert(a2v v)
	{
		v2f o;
		o.uv = v.texcoord.xy;
		float4 offset;
		// 初始化顶点偏移量
		offset.xyzw = float4(0.0, 0.0, 0.0, 0.0);
		// 计算偏移之前的顶点位置
		float4 v_before = mul(unity_ObjectToWorld, v.vertex);
		// 我们只希望对顶点的 Y 方向进行偏移（正弦型函数y=Asin(ωx+φ)+b）
		offset.y = _AmplitudeStrength * sin(_Frequency * _Time.y + (v_before.x + v_before.y* _Fold) * _InvWaveLength) * o.uv.x;

		//我们只需要把偏移量添加到顶点位置上，再进行正常的顶点变换即可
		o.pos = UnityObjectToClipPos(v.vertex + offset);

		o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = tex2D(_MainTex, i.uv);
	col.rgb *= _FlagColor.rgb;
	return col;
	}
		ENDCG
	}
	}
		FallBack "VertexLit"
}
