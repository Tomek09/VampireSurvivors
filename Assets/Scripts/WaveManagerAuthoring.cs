using System.Linq;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts {
	public class WaveManagerAuthoring : MonoBehaviour {

		[Header("Level")]
		public Vector2 LevelSize;

		[Header("Settings")]
		public float SpawnDelay;

		[Header("Prefabs")]
		public GameObject[] EnemyPrefabs;

		private class Baker : Baker<WaveManagerAuthoring> {

			public override void Bake(WaveManagerAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.None);

				DynamicBuffer<Entity> enemiesPrefab = new DynamicBuffer<Entity>();
				for (int i = 0; i < enemiesPrefab.Length; i++) {
					enemiesPrefab[i] = GetEntity(authoring.EnemyPrefabs[i], TransformUsageFlags.Dynamic);
				}

				AddComponent(entity, new WaveManager {
					// Level
					Width = authoring.LevelSize.x,
					Height = authoring.LevelSize.y,

					// Settings
					SpawnTime = authoring.SpawnDelay,

					// Prefabs
					EnemyPrefab = GetEntity(authoring.EnemyPrefabs[0], TransformUsageFlags.Dynamic)
				});
			}
		}
	}

	public struct WaveManager : IComponentData {
		// Level
		public float Width;
		public float Height;

		// Settings
		public float SpawnTime;

		// Prefabs
		public DynamicBuffer<Entity> EnemyPrefabs;

		public Entity GetPrefab() {
			int index = UnityEngine.Random.Range(0, EnemyPrefabs.Length);
			return EnemyPrefabs[index];
		}

		public float3 GetSpawnPosition() {
			float xPosition = UnityEngine.Random.Range(-Width, Width);
			float yPosition = UnityEngine.Random.Range(-Height, Height);
			return new float3(xPosition, yPosition, 0f);
		}
	}
}