using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private const string SceneName = "MainScene";


    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneName);
    }
}
