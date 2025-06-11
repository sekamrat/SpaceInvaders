using UnityEngine;

public class TesteWIP : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Em resumo, a unica coisa que voce precisa fazer é chamar esse addpoint toda vez que precisar colocar o ponto

                ScoreManager.instance.AddPoint();

        }
    }
}
