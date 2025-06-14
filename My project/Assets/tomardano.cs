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

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 posicaoAtual = transform.position;
        posicaoAtual.x += horizontal * velocidade * Time.deltaTime;
        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, limiteEsquerdo, limiteDireito);

        transform.position = posicaoAtual;
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
