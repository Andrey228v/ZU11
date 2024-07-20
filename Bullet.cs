using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction, float speed)
    {
        transform.position = transform.position + direction;
        transform.rotation = Quaternion.identity;
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * speed;
    }
}
