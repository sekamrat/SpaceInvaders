using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool gameSoundPause = false;
    bool gamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject soundMenu;
    
    void Update() // magia do menu
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false && gameSoundPause == false) 
        {
            Time.timeScale = 0;
            gamePaused = true;
            gameSoundPause = true;
            pauseMenu.SetActive(true);
            soundMenu.SetActive(false);
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) && gamePaused == true && gameSoundPause == false) // pausar basico
        {
            Time.timeScale = 1;
            gamePaused = false;
            pauseMenu.SetActive(false);
        }

        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) && gamePaused == true && gameSoundPause == true)  // pausar no menu de audio
        {
            gameSoundPause = false;
            gamePaused = true;
            pauseMenu.SetActive(true);
            soundMenu.SetActive(false);
        }
    }
}
