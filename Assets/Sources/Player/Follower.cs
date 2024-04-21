using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Rigidbody _rigidbody;
    private float _speedOfFollowing = 40f;
    private float _offsetDistance = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = _target.position - transform.position;
        direction = direction.normalized;
        Vector3 force = direction * _speedOfFollowing;

        if (CloseToTarget() == false)
        {
            _rigidbody.MovePosition(transform.position + force * Time.deltaTime);
        }
    }

    private bool CloseToTarget()
    {
        float lengthOfDifference = (_target.position - transform.position).magnitude;

        if (lengthOfDifference < _offsetDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}