using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    [SerializeField] private GameObject instructionScreen;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartLevel()
    {
        instructionScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
