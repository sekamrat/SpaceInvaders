using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tomardano : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip somExplosao;
    public int vidaMaxima = 3;
    private int vidaAtual;
    private bool isDead = false;

    void Start()
    {
        vidaAtual = vidaMaxima;
        ScoreManager.instance?.SetLife(vidaAtual);
    }

    void Update()
    {
        // Se o player est� morto e apertar espa�o, reinicia a cena
        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void TomarDano(int dano)
    {
        if (isDead) return;
        audioSource.pitch = UnityEngine.Random.Range(3f, 5f);
        audioSource.PlayOneShot(somExplosao);
        vidaAtual -= dano;
        Debug.Log("Jogador levou dano! Vida restante: " + vidaAtual);
        ScoreManager.instance?.SetLife(vidaAtual);

        if (vidaAtual <= 0)
        {
            StartCoroutine(Morrer());
        }
    }

    IEnumerator Morrer()
    {
        audioSource.PlayOneShot(somExplosao);
        Debug.Log("Jogador morreu!");
        ScoreManager.instance?.GameOver();
        isDead = true;
        gameObject.SetActive(false);
        // N�o reinicia a cena automaticamente, s� ao apertar espa�o
        yield break;
    }
    public bool IsDead()
    {
        return isDead;
    }
}
