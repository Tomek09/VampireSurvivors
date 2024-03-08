using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Players {
	public readonly partial struct PlayerMovementAspect : IAspect {

		public readonly RefRW<LocalTransform> transform;
		public readonly RefRO<PlayerInput> input;
		public readonly RefRO<PlayerMoveSpeed> moveSpeed;

		public void Tick(float deltaTime) {
			float2 inputValue = input.ValueRO.MoveInput;
			HandleMovement(inputValue, deltaTime);
			HandleRotation(inputValue);
		}

		private void HandleMovement(float2 inputValue, float deltaTime) {
			float3 direction = new float3(inputValue.x, inputValue.y, 0f);
			float3 newPosition = transform.ValueRO.Position + direction * moveSpeed.ValueRO.Value * deltaTime;
			transform.ValueRW.Position = newPosition;
		}

		private void HandleRotation(float2 inputValue) {
			if (Equals(inputValue, float2.zero)) {
				return;
			}

			float value = inputValue.x > 0 ? 0 : -1;
			transform.ValueRW.Rotation = new quaternion(0f, value, 0f, 0f);
		}
	}
}