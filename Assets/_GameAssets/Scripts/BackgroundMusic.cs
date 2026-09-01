using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance {get; private set;}
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _backgroundMusicButton;
    [SerializeField] private Image _musicOnImage;
    [SerializeField] private Image _musicOffImage;
    private bool isPaused;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
            OnPressedMusicButton();
            SetMusicIcon();
        }
    }
    // public void SetMusicMute(bool isMuted)
    // {
    //     _audioSource.mute = isMuted;
    // }
    // public void PlayBackgroundMusic(bool isMusicPlaying)
    // {
    //     if(isMusicPlaying && !_audioSource.isPlaying) _audioSource.Play();
    //     else if(!isMusicPlaying) _audioSource.Stop();
    // }
    private void SetMusicPause()
    {
        if (!isPaused)
        {_audioSource.Pause();}
        else{_audioSource.UnPause();}

        if (!isPaused)
        {isPaused = true;}
        else{isPaused = false;}   
    }
    public void OnPressedMusicButton()
    {
        if(_backgroundMusicButton == null) return;

        _backgroundMusicButton.onClick.AddListener(() => SetMusicPause());
        _backgroundMusicButton.onClick.AddListener(() => SetMusicIcon());
    }
    private void SetMusicIcon()
    {
        if(_musicOnImage == null || _musicOffImage == null) return;
        if (!isPaused)
        {
            _musicOnImage.enabled = true;
            _musicOffImage.enabled = false;
        }
        else
        {
            _musicOnImage.enabled = false;
            _musicOffImage.enabled = true;
        }
    }
    public void RegisterMusicButton(Button button, Image onImage, Image offImage)
    {
        _backgroundMusicButton = button;
        _musicOnImage = onImage;
        _musicOffImage = offImage;

        _backgroundMusicButton.onClick.RemoveAllListeners();
        _backgroundMusicButton.onClick.AddListener(() =>
        {
            SetMusicPause();
            SetMusicIcon();
        });

        SetMusicIcon();
    }
}
