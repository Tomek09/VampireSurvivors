using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts {
	public partial struct EnemyManagerSystem : ISystem {

		public void OnUpdate(ref SystemState state) {
			float3 desinationPoint = new float3(0, 0, 0);
			foreach (EnemyAspect enemy in SystemAPI.Query<EnemyAspect>()) {
				enemy.Tick(SystemAPI.Time.DeltaTime, desinationPoint);
			}
		}
	}
}