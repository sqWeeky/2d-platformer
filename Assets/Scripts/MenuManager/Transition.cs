using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private int _activeScene;

    public event Action LevelComplete;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            LevelComplete?.Invoke();
            UnLockLevel();
            _activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_activeScene + 1);
        }
    }

    private void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }
}