using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOvertxt;
    [SerializeField] private GameObject tapTxt;


    private void OnEnable()
    {
        Ball.gameover += StartGameOverCoroutine;
    }

    private void OnDisable()
    {
        Ball.gameover -= StartGameOverCoroutine;
    }

    private void StartGameOverCoroutine()
    {
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        gameOvertxt.SetActive(true);

        yield return new WaitForSecondsRealtime(1.5f);

        tapTxt.SetActive(true);

        while (!Input.anyKey)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
