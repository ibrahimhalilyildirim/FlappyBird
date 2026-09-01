using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] private Button _gameStartButton;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Image _musicOnImage;
    [SerializeField] private Image _musicOffImage;
    private void Awake()
    {
        BackgroundMusic.Instance.RegisterMusicButton(_musicButton, _musicOnImage, _musicOffImage);
        _gameStartButton.onClick.AddListener(() => SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE));
        
    }
}
