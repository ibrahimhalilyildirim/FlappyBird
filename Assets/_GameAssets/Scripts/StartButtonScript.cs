using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] private Button _gameStartButton;
    private void Awake()
    {
        _gameStartButton.onClick.AddListener(() => SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE));
        
    }
}
