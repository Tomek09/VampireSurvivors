using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Enemies {
	public partial struct EnemyMovementSystem : ISystem, ISystemStartStop {

		private Entity _playerEntity;

		public void OnCreate(ref SystemState state) {
			state.RequireForUpdate<Players.PlayerTag>();
		}

		public void OnStartRunning(ref SystemState state) {
			_playerEntity = SystemAPI.GetSingletonEntity<Players.PlayerTag>();
		}

		public void OnUpdate(ref SystemState state) {
			float3 desination = SystemAPI.GetComponent<LocalTransform>(_playerEntity).Position;

			foreach (EnemyMovementAspect aspect in SystemAPI.Query<EnemyMovementAspect>().WithAll<EnemyTag>()) {
				float deltaTime = SystemAPI.Time.DeltaTime;
				aspect.Tick(deltaTime, desination);
			}
		}

		public void OnStopRunning(ref SystemState state) { }
	}
}