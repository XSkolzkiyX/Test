using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIElements : MonoBehaviour
{
    public PlayerController Player;
    public static int Level = 1;

    public void NextButton()
    {
        Enemy.Speed *= 2;
        Level++;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PauseStartButton()
    {
        Player.isPlaying = !Player.isPlaying;
    }
}
