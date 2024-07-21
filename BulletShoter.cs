using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BulletShoter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _target;

    private bool _isShooting = true;

    public ObjectPool<Bullet> Pool { get; private set; }

    private void Start()
    {
        Pool = new ObjectPool<Bullet>(CreateObject);

        StartCoroutine(ShootingWorker());
    }

    private Bullet CreateObject()
    {
        return Instantiate(_bulletPrefab);
    }

    private IEnumerator ShootingWorker()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeWaitShooting);

        while (_isShooting)
        {
            Vector3 bulletDirection = (_target.position - transform.position).normalized;

            Bullet newBullet = Pool.Get();

            newBullet.Initialize(bulletDirection, _speed);

            yield return wait;
        }
    }
}
