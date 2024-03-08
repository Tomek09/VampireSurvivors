using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Players {
	public partial class PlayerInputSystem : SystemBase {

		private Inputs.GameControls _inputActions;
		private float2 _lastMoveInput = new float2(1f, 0f);

		protected override void OnCreate() {
			RequireForUpdate<PlayerTag>();

			_inputActions = new Inputs.GameControls();
		}

		protected override void OnStartRunning() {
			_inputActions.Enable();
		}

		protected override void OnUpdate() {
			Vector2 moveInput = _inputActions.Player.Movement.ReadValue<Vector2>();

			SystemAPI.SetSingleton(new PlayerInput {
				MoveInput = moveInput,
				LastMoveInput = _lastMoveInput
			});

			if (!Equals(Vector2.zero, moveInput)) {
				_lastMoveInput = moveInput;
			}
		}

		protected override void OnStopRunning() {
			_inputActions.Disable();
		}
	}
}