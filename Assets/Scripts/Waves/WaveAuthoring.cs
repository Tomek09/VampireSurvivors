using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Waves {
	public class WaveAuthoring : MonoBehaviour {

		[Header("Prefab")]
		[SerializeField] private Enemies.EnemyAuthoring _enemyPrefab;
		[SerializeField] private float _spawnInterval;

		private class Baker : Baker<WaveAuthoring> {
			public override void Bake(WaveAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.None);

				AddComponent(entity, new WaveInfo() {
					Prefab = GetEntity(authoring._enemyPrefab, TransformUsageFlags.Dynamic),
					SpawnInterval = authoring._spawnInterval
				});
			}
		}
	}
}