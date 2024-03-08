using Unity.Entities;

namespace Assets.Scripts.Projectiles {
	public partial struct ProjectileSystem : ISystem {
		
		public void OnUpdate(ref SystemState state) {
			foreach (ProjectileAspect aspect in SystemAPI.Query<ProjectileAspect>().WithAll<ProjectileTag>()) {
				float deltaTime = SystemAPI.Time.DeltaTime;
				aspect.Tick(deltaTime);
			}
		}
	}
}