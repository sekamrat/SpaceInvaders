using UnityEngine;

public class ShotTest : MonoBehaviour
{
    public AudioSource audioSource;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // se apertar espaço, toca o som do tiro e troca o pitch
        {
            audioSource.pitch = UnityEngine.Random.Range(1f, 2f);
            audioSource.Play();
        }
    }
}
