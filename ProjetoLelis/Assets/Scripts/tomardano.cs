using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tomardano : MonoBehaviour
{
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
        // Se o player está morto e apertar espaço, reinicia a cena
        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void TomarDano(int dano)
    {
        if (isDead) return;

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
        Debug.Log("Jogador morreu!");
        ScoreManager.instance?.GameOver();
        isDead = true;
        gameObject.SetActive(false);
        // Não reinicia a cena automaticamente, só ao apertar espaço
        yield break;
    }
    public bool IsDead()
    {
        return isDead;
    }
}
