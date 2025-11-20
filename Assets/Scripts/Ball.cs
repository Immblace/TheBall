using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 8f;
    public static event Action gameover;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 startDirection = new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.linearVelocity = startDirection * speed;
    }

    private void FixedUpdate()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        Vector2 v = rb.linearVelocity.normalized;

        if (MathF.Abs(v.x) < 0.25f)
        {
            v.x = MathF.Sign(v.x) * 0.25f;
        }

        if (MathF.Abs(v.y) < 0.25f)
        {
            v.y = MathF.Sign(v.y) * 0.25f;
        }

        rb.linearVelocity = v.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Idamagable>(out Idamagable idamagable))
        {
            idamagable.GetDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameOver")
        {
            gameover?.Invoke();
            Destroy(gameObject);
        }
    }

}
