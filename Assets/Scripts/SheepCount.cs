using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheepCount : MonoBehaviour
{
    [SerializeField] GameObject finishText;
    int requiredCount = 5;
    int enteredCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            enteredCount++;
            if (enteredCount >= requiredCount)
            {
                StartCoroutine(DelayLoadScene());
            }
        }
    }
    IEnumerator DelayLoadScene()
    {
        finishText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
