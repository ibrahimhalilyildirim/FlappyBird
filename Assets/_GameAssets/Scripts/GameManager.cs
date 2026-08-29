using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private GameState _currentGameState;
    public event Action<GameState> OnGameStateChanged;
    public void ChangeGameState(GameState gameState)
    {
       OnGameStateChanged?.Invoke(gameState); 
       _currentGameState = gameState;
       Debug.Log("Game State:" + gameState);
    }
    private void OnEnable() {
        ChangeGameState(GameState.Play);   
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }
}
