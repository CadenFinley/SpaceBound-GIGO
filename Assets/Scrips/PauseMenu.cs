using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameManager gameManager;
    public BallControls bc;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Restart()
    {
        bc.transform.position = new Vector2(gameManager.spawnPoint.x, gameManager.spawnPoint.y + 1);
        bc.StopMovement();
        if (bc.transform.position.y < 260)
        {
            bc.changeGrav(1);
        }
    }
}
