using UnityEngine;

public class movimentoplayer : MonoBehaviour
{
    public float velocidade = 5f;
    public float limiteEsquerdo = -7f;
    public float limiteDireito = 7f; 

    void Update()
    {
        float movimento = 0f;


        if (Input.GetKey(KeyCode.A))
        {
            movimento = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimento = 1f;
        }


        Vector3 novaPosicao = transform.position + Vector3.right * movimento * velocidade * Time.deltaTime;

 
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteEsquerdo, limiteDireito);


        transform.position = novaPosicao;
    }
}
