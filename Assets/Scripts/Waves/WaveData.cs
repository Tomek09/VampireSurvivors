using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Waves {

	public struct WaveInfo : IComponentData {
		public Entity Prefab;
		public float SpawnInterval;
	}
}