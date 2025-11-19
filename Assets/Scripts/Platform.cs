using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 mousePos;

    private void OnEnable()
    {
        Ball.gameover += DeletePlatform;
    }

    private void OnDisable()
    {
        Ball.gameover -= DeletePlatform;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.77f, 1.77f), transform.position.y, transform.position.z);
    }

    private void DeletePlatform()
    {
        Destroy(gameObject);
    }
}
