using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTimeline : MonoBehaviour
{
    [SerializeField] string name;
    private void Update()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;

    }
}
