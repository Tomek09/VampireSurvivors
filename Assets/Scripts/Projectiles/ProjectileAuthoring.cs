using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Projectiles {
	public class ProjectileAuthoring : MonoBehaviour {

		[Header("Values")]
		[SerializeField] private float _moveSpeed;

		private class Baker : Baker<ProjectileAuthoring> {
			public override void Bake(ProjectileAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent<ProjectileTag>(entity);
				AddComponent(entity, new ProjectileMoveSpeed { Value = authoring._moveSpeed });
			}
		}
	}
}