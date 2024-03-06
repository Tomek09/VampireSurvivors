using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts {
	public partial struct WaveManagerSystem : ISystem {

		private float _delay;

		[BurstCompile]
		public void OnUpdate(ref SystemState state) {
			if (!SystemAPI.TryGetSingleton(out WaveManager waveManager)) {
				return;
			}

			_delay -= SystemAPI.Time.DeltaTime;
			if (_delay <= 0) {
				RefreshTimer(ref waveManager);
				SpawnEnemies(ref state, ref waveManager);
			}
		}

		private void RefreshTimer(ref WaveManager waveManager) => _delay = waveManager.SpawnTime;

		private void SpawnEnemies(ref SystemState state, ref WaveManager waveManager) {
			Entity prefab = waveManager.GetPrefab();
			Entity enemy = state.EntityManager.Instantiate(prefab);
			state.EntityManager.SetComponentData(enemy, new LocalTransform {
				Position = waveManager.GetSpawnPosition(),
				Rotation = quaternion.identity,
				Scale = 1f
			});
		}
	}
}