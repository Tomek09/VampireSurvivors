using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Players {
	public class PlayerAuthoring : MonoBehaviour {

		[Header("Values")]
		[SerializeField] private float _moveSpeed = 5f;
		[SerializeField] private Projectiles.ProjectileAuthoring _projectilePrefab = null;

		private class Baker : Baker<PlayerAuthoring> {
			public override void Bake(PlayerAuthoring authoring) {
				Entity entity = GetEntity(TransformUsageFlags.Dynamic);

				AddComponent<PlayerTag>(entity);
				AddComponent<PlayerInput>(entity);
				AddComponent(entity, new PlayerMoveSpeed { Value = authoring._moveSpeed });
				AddComponent(entity, new PlayerWeapon {
					Prefab = GetEntity(authoring._projectilePrefab, TransformUsageFlags.Dynamic),
					FireRate = authoring._projectilePrefab.FireRate,
					CurrentFireRate = authoring._projectilePrefab.FireRate
				});

			}
		}
	}
}