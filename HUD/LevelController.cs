using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winScreen;
    [SerializeField] int timeToLoadNextScene = 5;

    private int numberOfAttackers = 0;
    private bool isTimerFinished = false;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    public void IncreaseNumberofAttackers()
    {
        numberOfAttackers++;
    }

    public void AttackersDestroyed()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && isTimerFinished)
        {
            StartCoroutine(WinScreen(timeToLoadNextScene));
        }
    }

    public void IsTimerFinished()
    {
        isTimerFinished = true;
        StopSpawning();
    }

    private IEnumerator WinScreen(int seconds)
    {
        winScreen.SetActive(true);
        winScreen.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
        yield return new WaitForSeconds(seconds);
        FindObjectOfType<SplashScreen>().LoadNextScene();
    }

    private void StopSpawning()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
