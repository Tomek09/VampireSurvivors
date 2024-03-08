using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Enemies {
	public class EnemyAuthoring : MonoBehaviour {

		[Header("Values")]
		[SerializeField] private float _moveSpeed = 5f;

		private class Baker : Baker<EnemyAuthoring> {
			public override void Bake(EnemyAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent<EnemyTag>(entity);
				AddComponent(entity, new Base.BaseMoveSpeed { Value = authoring._moveSpeed });
				AddComponent(entity, new Projectiles.ProjectileHitTag());
			}
		}
	}
}