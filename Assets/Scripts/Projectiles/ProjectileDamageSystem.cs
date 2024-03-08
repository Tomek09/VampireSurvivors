using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Projectiles {
	public partial struct ProjectileDamageSystem : ISystem {

		private const float DETECT_THRESHOLD = .15f;

		public void OnUpdate(ref SystemState state) {
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

			foreach ((RefRO<LocalTransform> projectileTransform, Entity projectileEntity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<ProjectileTag>().WithEntityAccess()) {
				foreach ((RefRO<LocalTransform> enemyTransform, Entity enemyEntity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Enemies.EnemyTag, ProjectileHitTag>().WithEntityAccess()) {
					float distance = math.lengthsq(projectileTransform.ValueRO.Position - enemyTransform.ValueRO.Position);
					if(distance > DETECT_THRESHOLD) {
						continue;
					}

					commandBuffer.AddComponent(enemyEntity, new Base.DestroyEntityTag());
					commandBuffer.AddComponent(projectileEntity, new Base.DestroyEntityTag());
				}
			}

			commandBuffer.Playback(state.EntityManager);
			commandBuffer.Dispose();
		}
	}
}