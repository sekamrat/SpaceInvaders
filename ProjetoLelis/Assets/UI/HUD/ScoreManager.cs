using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // vou precisar dessa instancia pra chamar 
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake() // é pra isso tocar beem no inicio do jogo
    {
        // Garante que só há uma instância
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        ScoreText.text = "SCORE " + "<" + score.ToString() + ">"; 
        HighscoreText.text = "HIGHSCORE " + "<" + highscore.ToString() + ">"; // Corrigido aqui
    }

    public void AddPoint()
    {
        score += 1;
        ScoreText.text = "SCORE " + "<" + score.ToString() + ">"; 
        
        if (highscore < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighscoreText.text = "HIGHSCORE " + "<" + highscore.ToString() + ">";
        }
    }
}