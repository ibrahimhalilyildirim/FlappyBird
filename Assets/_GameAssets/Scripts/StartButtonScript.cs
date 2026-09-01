using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] private Button _gameStartButton;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Image _musicOnImage;
    [SerializeField] private Image _musicOffImage;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TMP_Text _bestScoreText;


    

    private void Awake()
    {
        _gameStartButton.onClick.AddListener(() => SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE));
    }
    private void Start()
    {
        BackgroundMusic.Instance.RegisterMusicButton(_musicButton, _musicOnImage, _musicOffImage);


        int BestScore = PlayerPrefs.GetInt("BestScore" , 0);
        _bestScoreText.text = BestScore.ToString();
    }
}
