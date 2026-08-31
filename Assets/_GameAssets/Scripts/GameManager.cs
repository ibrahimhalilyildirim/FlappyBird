using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private GameState _currentGameState;
    public GameManager managerGame;
    public event Action<GameState> OnGameStateChanged;
    public Button _settingsButton;

    [SerializeField] private GameObject _settingsPopupUI;

    [SerializeField] private GameObject _gameOverUI;
    public bool _isGamePausePopupActive = false;

    private bool _isGameOverPopupActive = false;
    public void ChangeGameState(GameState gameState)
    {
       OnGameStateChanged?.Invoke(gameState); 
       _currentGameState = gameState;
       Debug.Log("Game State:" + gameState);
    }
    private void OnEnable() {
        ChangeGameState(GameState.Play);
        Time.timeScale = 1;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }
    public GameState GetGameState()
    {
        return _currentGameState;
    } 
    public void OnGameOver()
    {
        managerGame.ChangeGameState(GameState.GameOver);
        Time.timeScale = 0;
        _settingsButton.interactable= _isGamePausePopupActive;
        _gameOverUI.SetActive(!_isGameOverPopupActive);
        _isGameOverPopupActive = !_isGameOverPopupActive;
    }
     public void OnGamePause()
    {
        managerGame.ChangeGameState(GameState.Pause);
        Time.timeScale = 0;
        _settingsButton.interactable = _isGamePausePopupActive;
        _settingsPopupUI.SetActive(!_isGamePausePopupActive);
        _isGamePausePopupActive = !_isGamePausePopupActive;
    }
    public void OnGameResume()
    {
        managerGame.ChangeGameState(GameState.Play);
        Time.timeScale = 1;
        _settingsButton.enabled = _isGamePausePopupActive;
        _settingsPopupUI.SetActive(!_isGamePausePopupActive);
        _isGamePausePopupActive = !_isGamePausePopupActive;
    }

}
