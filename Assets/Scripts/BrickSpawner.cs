using System.Runtime.CompilerServices;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BrickPrefab;
    [SerializeField] private Transform startBrickPos;
    private Vector3 copyStartPos;
    private int rows = 4;
    private int colums = 11;
    private float intervalX = 0.3f;
    private float intervalY = 0.6f;


    private void Start()
    {
        copyStartPos = startBrickPos.position;
        SpawnBricks();
    }

    private void OnEnable()
    {
        Ball.gameover += DeleteAllBricks;
    }

    private void OnDisable()
    {
        Ball.gameover -= DeleteAllBricks;
    }

    private void SpawnBricks()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < colums; k++)
            {
                Instantiate(BrickPrefab, startBrickPos.position, Quaternion.identity, transform);
                startBrickPos.position = new Vector3(startBrickPos.position.x + intervalX, startBrickPos.position.y, 0f);
            }
            startBrickPos.position = new Vector3(copyStartPos.x, startBrickPos.position.y - intervalY, 0f);
        }
    }

    private void DeleteAllBricks()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform brick in transform)
            {
                Destroy(brick.gameObject);
            }
        }
    }
}
