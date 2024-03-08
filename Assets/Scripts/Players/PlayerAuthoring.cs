using System.Collections;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Players {
	public class PlayerAuthoring : MonoBehaviour {

		private class Baker : Baker<PlayerAuthoring> {
			public override void Bake(PlayerAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent<PlayerTag>(entity);
				AddComponent<PlayerInput>(entity);
				AddComponent(entity, new PlayerMoveSpeed { Value = 5f });
			}
		}
	}
}