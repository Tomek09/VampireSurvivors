using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Players {

	public struct PlayerTag : IComponentData { }

	public struct PlayerInput : IComponentData {
		public float2 Value;
	}

	public struct PlayerMoveSpeed : IComponentData {
		public float Value;
	}

}