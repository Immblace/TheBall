using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 touchPos;

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
        //mobile control
        SwipeMove(); 

        //pc control
        //MoveMouse(); 
    }

    private void SwipeMove()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = new Vector3(touchPos.x, transform.position.y, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.77f, 1.77f), transform.position.y, transform.position.z);
        }
    }

    private void MoveMouse()
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
