using Unity.Entities;

namespace Assets.Scripts.Game {
	public partial struct GameSystem : ISystem {

		public float GameTime;

		public void OnUpdate(ref SystemState state) {
			GameTime += SystemAPI.Time.DeltaTime;
		}
	}
}