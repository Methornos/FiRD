using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsMP : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSource;

    public void StartButton()
    {
        Click();
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Click();
        Application.Quit();
    }

    public void BackButton()
    {
        Click();
        SceneManager.LoadScene("MainMenu");
    }

    private void Click()
    {
        if(_clickSource)
            _clickSource.Play();
    }
}
