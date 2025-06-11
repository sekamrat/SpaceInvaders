using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] GameObject soundMenu;
    [SerializeField] GameObject pauseMenu;
    
    void Awake()
    {
        GameObject SoundMenu = GameObject.Find("SoundPanel");
    }

    public void SoundPause()
    {
        soundMenu.SetActive(true);
        pauseMenu.SetActive(false);

    }

    public void Resume()
    {
        soundMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
