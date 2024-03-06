using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts {
	public class WaveManagerAuthoring : MonoBehaviour {

		public float SpawnDelay;
		public GameObject[] EnemyPrefabs;

		private class Baker : Baker<WaveManagerAuthoring> {

			public override void Bake(WaveManagerAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.None);

				//DynamicBuffer<Entity> enemiesPrefab = new DynamicBuffer<Entity>();
				//for (int i = 0; i < enemiesPrefab.Length; i++) {
				//	enemiesPrefab[i] = GetEntity(authoring.EnemyPrefabs[i], TransformUsageFlags.Dynamic);
				//}

				AddComponent(entity, new WaveManager {
					SpawnDelay = authoring.SpawnDelay,
					EnemyPrefab = GetEntity(authoring.EnemyPrefabs[0], TransformUsageFlags.Dynamic)
				});
			}
		}
	}

	public struct WaveManager : IComponentData {
		public float SpawnDelay;
		public Entity EnemyPrefab;
	}
}