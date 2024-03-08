using Unity.Entities;

namespace Assets.Scripts.Waves {

	public struct WaveInfo : IComponentData {
		public Entity Prefab;
		public float SpawnInterval;
	}
}