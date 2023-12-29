using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public HealthBar healthBar;
    public float health = 100;
    [SerializeField] GameObject gameOver;
    private void Awake()
    {
        Instance = this;
        healthBar.SetHealth(health);
    }
    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(GameOver());
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
    IEnumerator GameOver()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(3);
        gameOver.SetActive(false);
        PauseMenu.Instance.Restart();
        Cursor.lockState = CursorLockMode.None;
    }
}
