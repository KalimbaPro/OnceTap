using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool attack;
		public bool pickup;
		public bool drop;

		public bool launchDrone;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		//public void Clear()
		//{
		//	move = Vector2.zero;
		//	look = Vector2.zero;
		//	sprint = false;
		//	attack = false;
		//	pickup = false;
		//	launchDrone = false;
		//}

		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}

		public void OnPickup(InputValue value)
		{
			PickupInput(value.isPressed);
		}

		public void OnDrop(InputValue value)
		{
			DropInput(value.isPressed);
		}
		public void OnLaunchDrone(InputValue value)
		{
			LaunchDroneInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
		}

		public void PickupInput(bool newPickupInput)
		{
			pickup = newPickupInput;
		}

		public void DropInput(bool newPickupInput)
		{
			drop = newPickupInput;
		}
		public void LaunchDroneInput(bool newLaunchDroneInput)
		{
			launchDrone = newLaunchDroneInput;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}