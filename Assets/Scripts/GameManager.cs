using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isPaused;
    public void PauseGame()
    {
        if(isPaused) //IF THE GAME IS PAUSED, THEN UNPAUSE
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else //IF THE GAME ISN'T PAUSED, THEN PAUSE
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
