using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts {
	public partial struct WaveManagerSystem : ISystem {

		private WaveManager _waveManager;
		private float _nextSpawnTime;

		public void OnCreate(ref SystemState state) {
			_waveManager = SystemAPI.GetSingleton<WaveManager>();
			RefreshTimer();
		}

		public void OnUpdate(ref SystemState state) {
			_nextSpawnTime -= SystemAPI.Time.DeltaTime;
			if (_nextSpawnTime <= 0) {
				RefreshTimer();
				SpawnEnemies();
			}
		}

		private void RefreshTimer() {
			_nextSpawnTime = _waveManager.SpawnDelay;
		}

		private void SpawnEnemies() {
			Entity enemyPrefab = _waveManager.GetRandomEnemy();
			Entity spawnedEntity = EntityManager.Instantiate(enemyPrefab);
		}
	}
}