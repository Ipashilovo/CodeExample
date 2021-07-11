using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Road road))
        {
            _animator.Play("Running");
            if (road.ObjectColor == _player.ObjectColor)
            {
                _player.Movement.ResetSpeed();
            }
        }
        
        if (other.TryGetComponent(out Finish finish))
        {
            _player.Movement.enabled = false;
            _animator.Play("Dance");
            _player.transform.rotation = Quaternion.Euler(_player.transform.rotation.eulerAngles + new Vector3(0, 180, 0));

            finish.PlayAllParticles();
        }

        if (other.TryGetComponent(out ColorGate gate))
        {
            _player.Movement.ReduceSpeed();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Road road))
        {
            if (_player.ObjectColor != road.ObjectColor)
            {
                _player.Movement.ReduceSpeed();
            }
            else
            {
                _player.Movement.ResetSpeed();
            }
        }
    }
}
