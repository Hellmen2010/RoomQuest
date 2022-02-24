using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadGame()
    {
        LoadFromFileInfo.loadFromFileState = loadingType.FromFile;
        SceneManager.LoadScene("Game");
    }

    public void NewGame()
    {
        LoadFromFileInfo.loadFromFileState = loadingType.NewGame;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
