using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Players {

	public struct PlayerTag : IComponentData { }

	public struct PlayerInput : IComponentData {
		public float2 MoveInput;
		public float2 LastMoveInput;
	}

	public struct PlayerMoveSpeed : IComponentData {
		public float Value;
	}

	public struct PlayerWeapon : IComponentData {
		public Entity Prefab;
		public float FireRate;
		public float CurrentFireRate;
	}
}