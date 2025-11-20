using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOvertxt;
    [SerializeField] private GameObject Winnertxt;
    [SerializeField] private GameObject tapTxt;
    [SerializeField] private GameObject ballObj;


    private void OnEnable()
    {
        Ball.gameover += StartGameOverCoroutine;
        BrickSpawner.win += StartWinnerOverCoroutine;
    }

    private void OnDisable()
    {
        Ball.gameover -= StartGameOverCoroutine;
        BrickSpawner.win += StartWinnerOverCoroutine;
    }

    private void StartGameOverCoroutine()
    {
        StartCoroutine(RestartGame());
    }

    private void StartWinnerOverCoroutine()
    {
        StartCoroutine(WinGame());
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

    private IEnumerator WinGame()
    {
        Destroy(ballObj);
        Winnertxt.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        tapTxt.SetActive(true);

        while (!Input.anyKey)
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
