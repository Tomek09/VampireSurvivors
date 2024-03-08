using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Players {
	public partial struct PlayerMovementSystem : ISystem {

		public void OnCreate(ref SystemState state) {
			state.RequireForUpdate<PlayerTag>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state) {
			float deltaTime = SystemAPI.Time.DeltaTime;
			foreach (PlayerMovementAspect playerMove in SystemAPI.Query<PlayerMovementAspect>()) {
				playerMove.Tick(deltaTime);
			}
		}
	}
}