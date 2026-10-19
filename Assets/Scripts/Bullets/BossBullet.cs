
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 direction = Vector2.left;
    private BossBulletPool bulletPool;

    public void Initialize(BossBulletPool pool, Vector2 shootDirection)
    {
        bulletPool = pool;
        direction = shootDirection.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (transform.position.x < -12f ||
            transform.position.x > 12f ||
            transform.position.y < -7f ||
            transform.position.y > 7f)
        {
            ReturnToPool();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLives playerLives = other.GetComponent<PlayerLives>();

            if (playerLives == null)
                playerLives = other.GetComponentInParent<PlayerLives>();

            if (playerLives != null)
                playerLives.TakeDamage();

            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        if (bulletPool != null)
        {
            bulletPool.ReturnBullet(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
