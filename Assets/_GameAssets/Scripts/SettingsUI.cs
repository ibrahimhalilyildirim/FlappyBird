using System;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header ("References")]
    [Header("Buttons")]
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _resumeButton;
    private GameState _gameState;
    public GameManager managerGame;
    // public Time _currentTime = Time.timeScale;

    
    [SerializeField] private Button _musicButton;
    [SerializeField] private Image _musicOnImage;
    [SerializeField] private Image _musicOffImage;

    [SerializeField] private Button _settingsMainMenuButton;
    [SerializeField] private Button _gameOverMainMenuButton;
    private void Awake()
    {
        _settingsMainMenuButton.onClick.AddListener(() => LoadMainMenu());
        _gameOverMainMenuButton.onClick.AddListener(() => LoadMainMenu());


        BackgroundMusic.Instance.RegisterMusicButton(_musicButton, _musicOnImage, _musicOffImage);
        _retryButton.onClick.AddListener(() => SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE));

        managerGame._settingsButton.onClick.AddListener(() =>
        { 
            if(_gameState == GameState.Play)
            {
            managerGame.OnGamePause();
            }
        });
        _resumeButton.onClick.AddListener(() => managerGame.OnGameResume());
    }
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(Consts.SceneNames.MAIN_MENU_SCENE);
        Time.timeScale = 1;
    }
}
