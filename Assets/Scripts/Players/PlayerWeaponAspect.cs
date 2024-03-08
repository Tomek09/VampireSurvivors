using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Players {
	public readonly partial struct PlayerWeaponAspect : IAspect {

		public readonly RefRW<LocalTransform> transform;
		public readonly RefRO<PlayerInput> input;
		public readonly RefRW<PlayerWeapon> weapon;

		public void Tick(float deltaTime) {
			if (weapon.ValueRO.Timer > 0) {
				weapon.ValueRW.Timer -= deltaTime;
			}
		}

		public void RestartTimer() => weapon.ValueRW.Timer = weapon.ValueRO.AttackInterval;

		public bool IsReady() => weapon.ValueRO.Timer <= 0f;

		public quaternion GetProjecitleRotation() {

			float2 inputValue = input.ValueRO.LastMoveInput;
			if(Equals(inputValue, float2.zero)) {
				return quaternion.identity;
			}

			float3 up = new float3(inputValue.x, inputValue.y, 0f);
			quaternion rotation = quaternion.LookRotation(new float3(0f, 0f, 1f), up);
			return rotation;

		}
	}
}