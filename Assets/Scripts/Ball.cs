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
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
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
