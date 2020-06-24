using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float loadNextSceneInSeconds = 4f;

    private int currentSceneIndex;
    private void Awake()
    {
        GetActiveScene();
    }

    private void GetActiveScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene());
        }
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(loadNextSceneInSeconds);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(Tags.SCENE_GAME_OVER);
    }

    public void StartScreen()
    {
        SceneManager.LoadScene(Tags.SCENE_START_MENU);
    }

     public void OptionsScreen()
    {
        SceneManager.LoadScene(Tags.SCENE_OPTIONS_MENU);
    }
}
