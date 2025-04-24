using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool _isPaused = false;
    public void PauseGame()
    {
        if(_isPaused) //IF THE GAME IS PAUSED, THEN UNPAUSE
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
        else //IF THE GAME ISN'T PAUSED, THEN PAUSE
        {
            Time.timeScale = 0;
            _isPaused = true;
        }
    }
}
