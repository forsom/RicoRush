using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 1f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Vector2 initialDirection = new Vector2(1, 0).normalized;
        _rb.velocity = initialDirection * ballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Rigidbody2D platformRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Базове відбиття від нормалі зіткнення
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectedVelocity = Vector2.Reflect(_rb.velocity.normalized, normal);

            // Додаємо вплив швидкості платформи по Y
            float impactFactor = Mathf.Clamp(Mathf.Abs(platformRb.velocity.y) / 5f, 0.5f, 2f);
            reflectedVelocity.y += platformRb.velocity.y * impactFactor;

            // Нормалізуємо та встановлюємо швидкість
            _rb.velocity = reflectedVelocity.normalized * ballSpeed;
        }
    }
}
