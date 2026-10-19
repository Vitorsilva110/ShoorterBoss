
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public BossBulletPool bulletPool;
    public Transform firePoint;
    public float shootInterval = 1f;
    public float bulletSpeed = 5f;
    public float doubleShotOffset = 0.25f;

    public void Shoot()
    {
        ShootBullet(Vector2.left, firePoint.position);
    }

    public void ShootDouble()
    {
        if (firePoint == null)
        {
            Debug.LogWarning("BossShooter: configure o Fire Point.");
            return;
        }

        ShootBullet(
            Vector2.left,
            firePoint.position + Vector3.up * doubleShotOffset
        );

        ShootBullet(
            Vector2.left,
            firePoint.position + Vector3.down * doubleShotOffset
        );
    }

    public void ShootTriple()
    {
        if (firePoint == null)
        {
            Debug.LogWarning("BossShooter: configure o Fire Point.");
            return;
        }

        ShootBullet(
            Vector2.left,
            firePoint.position
        );

        ShootBullet(
            new Vector2(-1f, 0.5f),
            firePoint.position
        );

        ShootBullet(
            new Vector2(-1f, -0.5f),
            firePoint.position
        );
    }

    private void ShootBullet(Vector2 direction, Vector3 position)
    {
        if (bulletPool == null || firePoint == null)
        {
            Debug.LogWarning(
                "BossShooter: configure o Bullet Pool e o Fire Point."
            );
            return;
        }

        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.identity;

        BossBullet bossBullet = bullet.GetComponent<BossBullet>();

        if (bossBullet != null)
        {
            bossBullet.speed = bulletSpeed;
            bossBullet.Initialize(bulletPool, direction);
        }
        else
        {
            Debug.LogError(
                "O Prefab BossBullet não possui o script BossBullet."
            );

            bulletPool.ReturnBullet(bullet);
        }
    }
}
