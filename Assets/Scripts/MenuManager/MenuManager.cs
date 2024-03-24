using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanale;
    [SerializeField] private GameObject _levelPanale;
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void StartGame()
    {
        _menu.SetActive(false);
        _levelPanale.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsPanel()
    {
        _menu.SetActive(false);
        _settingPanale.SetActive(true);
    }

    public void Exit()
    {
        _menu.SetActive(true);
        _settingPanale.SetActive(false);
    }
}