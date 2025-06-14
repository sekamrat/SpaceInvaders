using UnityEngine;

public class tomardano : MonoBehaviour
{
    public float velocidade = 5f;
    public float limiteEsquerdo = -7f;
    public float limiteDireito = 7f;

    public int vidaMaxima = 3;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log("Jogador levou dano! Vida restante: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Jogador morreu!");
 
        gameObject.SetActive(false);

    }
}
