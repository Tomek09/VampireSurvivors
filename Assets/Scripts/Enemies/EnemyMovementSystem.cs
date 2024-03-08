using Assets.Scripts.Base;
using Unity.Burst;
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
			float deltaTime = SystemAPI.Time.DeltaTime;
			float3 desination = SystemAPI.GetComponent<LocalTransform>(_playerEntity).Position;

			new EnemyMoveJob {
				DeltaTime = deltaTime,
				PlayerPosition = desination
			}.ScheduleParallel();
		}

		public void OnStopRunning(ref SystemState state) { }

		[BurstCompile]
		[WithAll(typeof(EnemyTag))]
		public partial struct EnemyMoveJob : IJobEntity {
			public float DeltaTime;
			public float3 PlayerPosition;

			[BurstCompile]
			private void Execute(ref LocalTransform transform, in BaseMoveSpeed moveSpeed) {
				float3 direction = math.normalizesafe(PlayerPosition - transform.Position);
				transform.Position += direction * moveSpeed.Value * DeltaTime;
			}
		}
	}
}