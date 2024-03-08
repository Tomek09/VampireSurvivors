using Unity.Entities;

namespace Assets.Scripts.Players {
	public partial struct PlayerMovementSystem : ISystem {

		public void OnCreate(ref SystemState state) {
			state.RequireForUpdate<PlayerTag>();
		}

		public void OnUpdate(ref SystemState state) {
			foreach (PlayerMovementAspect aspect in SystemAPI.Query<PlayerMovementAspect>().WithAll<PlayerTag>()) {
				float deltaTime = SystemAPI.Time.DeltaTime;
				aspect.Tick(deltaTime);
			}
		}
	}
}