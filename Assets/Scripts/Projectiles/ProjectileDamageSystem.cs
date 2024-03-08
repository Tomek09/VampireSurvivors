using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Assets.Scripts.Projectiles {
	public partial struct ProjectileDamageSystem : ISystem {

		public void OnUpdate(ref SystemState state) {
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

			foreach (RefRO<LocalTransform> projectileTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<ProjectileTag>()) {
				foreach ((RefRO<LocalTransform> enemyTransform, Entity enemyEntity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Enemies.EnemyTag, ProjectileHitTag>().WithEntityAccess()) {
					float distance = math.lengthsq(projectileTransform.ValueRO.Position - enemyTransform.ValueRO.Position);
					if (distance <= .05f) {
						commandBuffer.AddComponent(enemyEntity, new Base.DestroyEntityTag());
					}
				}
			}

			commandBuffer.Playback(state.EntityManager);
			commandBuffer.Dispose();
		}
	}
}