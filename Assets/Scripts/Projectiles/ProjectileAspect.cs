using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Projectiles {
	public readonly partial struct ProjectileAspect : IAspect {

		public readonly RefRW<LocalTransform> transform;
		public readonly RefRO<Base.BaseMoveSpeed> moveSpeed;

		public void Tick(float deltaTime) {
			float3 direction = transform.ValueRO.Up();
			float3 newPosition = transform.ValueRO.Position + direction * moveSpeed.ValueRO.Value * deltaTime;
			transform.ValueRW.Position = newPosition;
		}
	}
}