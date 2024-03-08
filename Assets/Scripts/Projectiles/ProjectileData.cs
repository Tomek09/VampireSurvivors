using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Projectiles {

	public struct ProjectileTag : IComponentData { }

	public struct ProjectileMoveSpeed : IComponentData {
		public float Value;
	}

}