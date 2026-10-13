
using UnityEngine;
using UnityEngine.Pool;

public class BossBulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    private ObjectPool<GameObject> pool;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                return bullet;
            },
            actionOnGet: bullet => bullet.SetActive(true),
            actionOnRelease: bullet => bullet.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 50
        );
    }

    public GameObject GetBullet()
    {
        return pool.Get();
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (bullet != null && bullet.activeSelf)
        {
            pool.Release(bullet);
        }
    }
}
