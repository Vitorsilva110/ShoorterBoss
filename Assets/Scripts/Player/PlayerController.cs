using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(vertical, 0f).normalized * -1f;

        transform.Translate(movement * speed * Time.deltaTime);

        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}