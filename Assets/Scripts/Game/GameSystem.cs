using System.Collections;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Game {
	public partial struct GameSystem : ISystem {

		public float GameTime;

		public void OnUpdate(ref SystemState state) {
			GameTime += SystemAPI.Time.DeltaTime;
		}
	}
}