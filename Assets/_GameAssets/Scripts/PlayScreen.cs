using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScreen : MonoBehaviour
{
    [SerializeField] private Button _playScreenButton;
    private void Awake()
    {
        _playScreenButton.onClick.AddListener(() => LoadGameScene());
        
    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene(Consts.SceneNames.GAME_SCENE);
    }
}
