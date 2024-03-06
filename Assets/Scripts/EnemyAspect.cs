using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts {
	public readonly partial struct EnemyAspect : IAspect {

		public readonly RefRW<LocalTransform> transform;
		public readonly RefRO<EnemyMovement> movement;


		public void Tick(float deltaTime, float3 desinationPoint) {
			float3 direction = desinationPoint - transform.ValueRO.Position;
			transform.ValueRW = transform.ValueRW.Translate(direction * movement.ValueRO.MoveSpeed * deltaTime);
		}
	}
}