
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Configurações do tiro")]
    public PlayerBulletPool bulletPool;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPool == null || firePoint == null)
        {
            Debug.LogWarning(
                "Configure o Bullet Pool e o Fire Point no Inspector."
            );
            return;
        }

        GameObject bullet = bulletPool.GetBullet();

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();

        if (playerBullet != null)
        {
            playerBullet.Initialize(bulletPool);
        }
        else
        {
            Debug.LogError("A bala precisa ter o componente PlayerBullet.");
            bulletPool.ReturnBullet(bullet);
        }
    }
}
