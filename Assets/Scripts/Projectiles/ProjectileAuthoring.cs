using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Projectiles {
	public class ProjectileAuthoring : MonoBehaviour {

		[field: Header("Values")]
		[field: SerializeField] public float FireRate { get; private set; }
		[field: SerializeField] public float MoveSpeed { get; private set; }

		private class Baker : Baker<ProjectileAuthoring> {
			public override void Bake(ProjectileAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent<ProjectileTag>(entity);
				AddComponent(entity, new ProjectileMoveSpeed { Value = authoring.MoveSpeed });
			}
		}
	}
}