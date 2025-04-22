using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool _isPaused = false;
    public static void PauseGame()
    {
        if(_isPaused) //IF THE GAME IS PAUSED, AND THE PLAYER PRESSES THE PAUSE BUTTON, THEN UNPAUSE
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
        else //IF THE GAME ISN'T PAUSED, AND THE PLAYER PRESSES THE PAUSE BUTTON, THEN PAUSE
        {
            Time.timeScale = 0;
            _isPaused = true;
        }
    }
}
