using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Projectiles {

	public struct ProjectileTag : IComponentData { }

	public struct ProjectileMoveSpeed : IComponentData {
		public float Value;
	}
}