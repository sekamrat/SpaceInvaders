using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI lifeScoreText;
    public GameObject restartText;

    public tomardano player;

    private int score = 0;
    private int highscore = 0;
    private int vidaAtual = 3;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        // Score por tempo (1 ponto por segundo)
        ScoreManager.instance?.AddTimeScore(Time.deltaTime);

        if (player != null && player.IsDead())
        {
            restartText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                SceneManager.LoadScene("MainGame");
            }
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        score = 0;
        UpdateScoreUI();
    }

    // Chame este método para adicionar pontos (ex: ao destruir inimigo)
    public void AddPoint(int pontos = 1)
    {
        score += pontos;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
    }

    // Chame este método para atualizar a vida na UI
    public void SetLife(int vida)
    {
        vidaAtual = vida;
        if (lifeScoreText != null)
            lifeScoreText.text = "LIVES LEFT <" + vidaAtual + ">";
    }

    // Se quiser score por tempo, chame este método no Update do GameManager
    public void AddTimeScore(float delta)
    {
        score += Mathf.FloorToInt(delta);
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "SCORE <" + score.ToString() + ">";
        if (highscoreText != null)
            highscoreText.text = "HIGHSCORE <" + highscore.ToString() + ">";
        if (lifeScoreText != null)
            lifeScoreText.text = "LIVES LEFT <" + vidaAtual + ">";
    }

    // Se quiser resetar o score ao reiniciar a cena
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Para acessar o score atual
    public int GetScore()
    {
        return score;
    }

    // Para acessar o highscore atual
    public int GetHighscore()
    {
        return highscore;
    }
    public void GameOver()
    {
        // Aqui você pode adicionar lógica extra se quiser, como pausar o score, mostrar painel de game over, etc.
        // No mínimo, salve o highscore se necessário.
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
    }

}
