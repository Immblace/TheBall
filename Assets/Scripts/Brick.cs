using UnityEngine;

public class Brick : MonoBehaviour, Idamagable
{
    private int health;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = Random.Range(1, 4);

        switch (health)
        {
            case 1:
                spriteRenderer.color = Color.red;
                break;

            case 2:
                spriteRenderer.color = Color.yellow;
                break;
            case 3:
                spriteRenderer.color = Color.green;
                break;
        }
    }

    public void GetDamage()
    {
        health--;

        if (health == 0)
        {
            Destroy(gameObject);
        }
        else if (health == 1)
        {
            spriteRenderer.color = Color.red;
        }
        else if (health == 2)
        {
            spriteRenderer.color = Color.yellow;
        }
    }
}
