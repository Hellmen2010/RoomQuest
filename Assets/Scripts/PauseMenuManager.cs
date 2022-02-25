using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public void NewGame()
    {
        LoadFromFileInfo.loadFromFileState = loadingType.NewGame;
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame()
    {
        Input.GetKeyUp(KeyCode.Escape);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
