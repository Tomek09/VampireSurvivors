using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts {
	public class EnemyMovementAuthoring : MonoBehaviour {

		public float MoveSpeed;

		private class Baker : Baker<EnemyMovementAuthoring> {

			public override void Bake(EnemyMovementAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);
				AddComponent(entity, new EnemyMovement {
					MoveSpeed = authoring.MoveSpeed
				});
			}
		}
	}

	public struct EnemyMovement : IComponentData {
		public float MoveSpeed;
	}
}