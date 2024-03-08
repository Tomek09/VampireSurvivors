using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Enemies {
	public readonly partial struct EnemyMovementAspect : IAspect {

		public readonly RefRW<LocalTransform> transform;
		public readonly RefRO<Base.BaseMoveSpeed> moveSpeed;


		public void Tick(float deltaTime, float3 destination) {
			HandleMovement(deltaTime, destination);
		}

		private void HandleMovement(float deltaTime, float3 destination) {
			float3 direction = math.normalize(destination - transform.ValueRO.Position);
			float3 newPosition = transform.ValueRO.Position + direction * moveSpeed.ValueRO.Value * deltaTime;
			transform.ValueRW.Position = newPosition;
		}
	}
}