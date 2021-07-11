using UnityEngine;
using Lean.Touch;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private Animator _animator;

	private void OnEnable()
	{
		LeanTouch.OnFingerSwipe += HandleFingerSwipe;
	}

	private void OnDisable()
	{
		LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
	}

	private void HandleFingerSwipe(LeanFinger finger)
	{
		if (finger != null)
		{
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
            {
                Vector2 deltaNormalized = finger.SwipeScreenDelta.normalized;
                int indexModifier = Mathf.RoundToInt(deltaNormalized.x);
                Road road = _player.RoadHandler.SetCurrentRoad(indexModifier);
                _player.Movement.SwitchRoad(road);
            }
        }
	}
}
