using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float _ballSpeed = 1f;
    private Vector2 initialDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialDirection = new Vector2(1, 0).normalized;
        rb.velocity = initialDirection * _ballSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vector2 firstContact = collision.contacts[0].normal;
            rb.velocity = Vector2.Reflect(rb.velocity.normalized,firstContact) * _ballSpeed;
        }
    }
}