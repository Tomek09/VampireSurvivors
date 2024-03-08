using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.Base {
	public partial struct DestroyByTimeSystem : ISystem {

		public void OnUpdate(ref SystemState state) {
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

			foreach ((RefRW<DestroyByTime> destroyByTime, Entity entity) in SystemAPI.Query<RefRW<DestroyByTime>>().WithEntityAccess()) {
				destroyByTime.ValueRW.Value -= SystemAPI.Time.DeltaTime;

				if (destroyByTime.ValueRO.Value <= 0) {
					commandBuffer.AddComponent(entity, new DestroyEntityTag());
				}
			}

			commandBuffer.Playback(state.EntityManager);
			commandBuffer.Dispose();
		}
	}
}