using System.Collections;
using System.Linq.Expressions;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Players {
	public partial class PlayerInputSystem : SystemBase {

		private Inputs.GameControls _inputActions;
		private Entity _playerEntity;

		protected override void OnCreate() {
			RequireForUpdate<PlayerTag>();

			_inputActions = new Inputs.GameControls();
		}

		protected override void OnStartRunning() {
			_inputActions.Enable();

			_playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
		}

		protected override void OnUpdate() {
			Vector2 moveInput = _inputActions.Player.Movement.ReadValue<Vector2>();

			SystemAPI.SetSingleton(new PlayerInput { Value = moveInput });
		}

		protected override void OnStopRunning() {
			_inputActions.Disable();

			_playerEntity = Entity.Null;
		}
	}
}