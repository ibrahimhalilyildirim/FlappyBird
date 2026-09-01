using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int _bestScore;
    private GameState _currentGameState;
    public GameManager managerGame;
    public event Action<GameState> OnGameStateChanged;
    public Button _settingsButton;
    private StartButtonScript _startButtonScript;
    [SerializeField] private GameObject _settingsPopupUI;

    [SerializeField] private GameObject _gameOverUI;
    public AudioManager _managerAudio;

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
        
        if(score > _bestScore)
        {
            _bestScore = score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
            PlayerPrefs.Save();
        }
    }
    public GameState GetGameState()
    {
        return _currentGameState;
    } 
    public void OnGameOver()
    {
        managerGame.ChangeGameState(GameState.GameOver);
        Time.timeScale = 0;
        _managerAudio._deadSound.Play();
        _settingsButton.interactable= _isGamePausePopupActive;
        _gameOverUI.SetActive(!_isGameOverPopupActive);
        _isGameOverPopupActive = !_isGameOverPopupActive;
    }
     public void OnGamePause()
    {
        managerGame.ChangeGameState(GameState.Pause);
        Time.timeScale = 0;
        _isGamePausePopupActive = true;
        _settingsButton.interactable = false;
        _settingsPopupUI.SetActive(true);
    }    public void OnGameResume()
    {
        managerGame.ChangeGameState(GameState.Play);
        Time.timeScale = 1;
        _isGamePausePopupActive = false;
        _settingsButton.interactable = true;
        _settingsPopupUI.SetActive(false);
    }
    
    public int UpdateBestScore()
    {
        if(score > _bestScore)
        {
            return score;
        }
        else
        {
            return _bestScore;
        }
    }
    private void Awake()
    {
        Instance = this;
        _bestScore = PlayerPrefs.GetInt("BestScore" , 0);
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}
