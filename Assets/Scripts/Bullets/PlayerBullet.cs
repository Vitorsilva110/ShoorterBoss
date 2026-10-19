
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    public float lifeTime = 3f;

    private PlayerBulletPool bulletPool;

    public void Initialize(PlayerBulletPool pool)
    {
        bulletPool = pool;
        CancelInvoke(nameof(ReturnToPool));
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();

            if (bossHealth == null)
                bossHealth = other.GetComponentInParent<BossHealth>();

            if (bossHealth != null)
                bossHealth.TakeDamage(damage);

            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        CancelInvoke(nameof(ReturnToPool));

        if (bulletPool != null)
            bulletPool.ReturnBullet(gameObject);
        else
            gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(ReturnToPool));
    }
}
