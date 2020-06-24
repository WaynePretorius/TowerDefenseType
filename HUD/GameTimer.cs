using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Represented in seconds")]
    [SerializeField] private float levelTime = 10f;
    
    private Slider timeSlider;
    private LevelController levelController;

    private bool isLevelFinished = false;

    private void Awake()
    {
        AwakeFunctions();
    }

    private void AwakeFunctions()
    {
        timeSlider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
        AdjustDifficulty(PlayerPrefsController.GetDifficulty());
    }

    private void AdjustDifficulty(float difficulty)
    {
        levelTime *= difficulty;
    }

    void Update()
    {
        GameTimerInProgress();
    }

    private void GameTimerInProgress()
    {
        if (isLevelFinished) { return; }

        timeSlider.value = Time.timeSinceLevelLoad / levelTime;
        IsTimerFinished();
    }

    private void IsTimerFinished()
    {
        bool isTimerFinished = Time.timeSinceLevelLoad >= levelTime;

        if (isTimerFinished)
        {
            levelController.IsTimerFinished();
            isLevelFinished = true;
        }
    }
}
