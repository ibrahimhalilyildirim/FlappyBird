using System;
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
    [SerializeField] private Button _soundButton;
    private GameState _gameState;
    public GameManager managerGame;
    // public Time _currentTime = Time.timeScale;

    
    [SerializeField] private Button _musicButton;
    [SerializeField] private Image _musicOnImage;
    [SerializeField] private Image _musicOffImage;
    private void Awake()
    {
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
}
