using System.IO;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts.Waves {
	public partial struct WaveSystem : ISystem, ISystemStartStop {

		private WaveInfo _waveInfo;
		private float _currentSpawnTime;

		private int _spawnIndex;
		private int _spawnIndexMax;
		private float _spawnRadius;

		public void OnStart(ref SystemState state) {
			state.RequireForUpdate<WaveInfo>();
		}

		public void OnStartRunning(ref SystemState state) {
			_waveInfo = SystemAPI.GetSingleton<WaveInfo>();
			_currentSpawnTime = _waveInfo.SpawnInterval;

			_spawnIndex = 0;
			_spawnIndexMax = 10;
			_spawnRadius = 9.5f;
		}

		public void OnUpdate(ref SystemState state) {
			_currentSpawnTime -= SystemAPI.Time.DeltaTime;

			if (_currentSpawnTime <= 0) {
				RestartTimer();

				Entity enemy = state.EntityManager.Instantiate(_waveInfo.Prefab);
				state.EntityManager.SetComponentData(enemy, new LocalTransform {
					Position = GetPosition(),
					Rotation = quaternion.identity,
					Scale = 1
				});
			}
		}

		public void OnStopRunning(ref SystemState state) { }

		private void RestartTimer() => _currentSpawnTime = _waveInfo.SpawnInterval;

		private float3 GetPosition() {
			float angle = _spawnIndex * math.PI * 2 / _spawnIndexMax;
			float xPosition = math.cos(angle) * _spawnRadius;
			float yPosition = math.sin(angle) * _spawnRadius;

			_spawnIndex += 1;
			if (_spawnIndex >= _spawnIndexMax) {
				_spawnIndex = 0;
			}

			return new float3(xPosition, yPosition, 0f);

		}
	}
}