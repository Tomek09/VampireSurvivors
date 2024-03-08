using Unity.Collections;
using Unity.Entities;

namespace Assets.Scripts.Base {
	public partial struct DestroyEntitySystem : ISystem {

		public void OnUpdate(ref SystemState state) {
			EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.Temp);

			foreach ((RefRW<DestroyEntityTag> _, Entity entity) in SystemAPI.Query<RefRW<DestroyEntityTag>>().WithEntityAccess()) {
				commandBuffer.DestroyEntity(entity);
			}

			commandBuffer.Playback(state.EntityManager);
			commandBuffer.Dispose();
		}
	}
}