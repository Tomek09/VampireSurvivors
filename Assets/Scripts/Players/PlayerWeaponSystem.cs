using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Assets.Scripts.Players {
	public partial struct PlayerWeaponSystem : ISystem {

		public void OnCreate(ref SystemState state) {
			state.RequireForUpdate<PlayerTag>();
		}

		public void OnUpdate(ref SystemState state) {
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

			foreach (PlayerWeaponAspect aspect in SystemAPI.Query<PlayerWeaponAspect>().WithAll<PlayerTag>()) {
				float deltaTime = SystemAPI.Time.DeltaTime;

				aspect.Tick(deltaTime);
				if (!aspect.IsReady()) {
					continue;
				}

				Entity spawnedProjectile = commandBuffer.Instantiate(aspect.weapon.ValueRO.Prefab);
				commandBuffer.SetComponent(spawnedProjectile, new LocalTransform {
				   Position = aspect.transform.ValueRO.Position,
				   Rotation = aspect.GetProjecitleRotation(),
				   Scale = 1f
				});

				aspect.RestartTimer();
			}

			commandBuffer.Playback(state.EntityManager);
			commandBuffer.Dispose();
		}
	}
}