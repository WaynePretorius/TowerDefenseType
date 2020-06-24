using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 5f;

    [SerializeField] GameObject[] animControllers;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int index = Random.Range(0, animControllers.Length);
        StartCoroutine(PlayAnimations(index));
        if (!audioSource) { return; }
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
       
    }

    private IEnumerator PlayAnimations(int index)
    {
        animControllers[index].SetActive(true);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        animControllers[index].GetComponent<Animator>().SetBool(Tags.ANIM_ISATTACKING, true);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        animControllers[index].GetComponent<Animator>().SetBool(Tags.ANIM_ISATTACKING, false);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        animControllers[index].SetActive(false);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        int indexNumber = Random.Range(0, animControllers.Length);
        StartCoroutine(PlayAnimations(indexNumber));
    }
}
