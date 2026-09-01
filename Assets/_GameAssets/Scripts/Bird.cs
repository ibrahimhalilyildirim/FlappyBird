using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class Bird : MonoBehaviour
{
    public bool isDead;
    [Header("Movement Settings")]
    [SerializeField] private float velocity = 1f;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private AudioManager _managerAudio;
    public GameManager managerGame;
    void Update()
    {   
        //GetMouseButtonDown 1 kez input alır. GetMouseButton basılı tutulduğu sürece input alır.
    bool mousePressed = Mouse.current?.leftButton.wasPressedThisFrame ?? false;
    bool touchPressed = Touchscreen.current?.primaryTouch.press.wasPressedThisFrame ?? false;
    
    if(managerGame.GetGameState() == GameState.Play && (mousePressed || touchPressed) && !EventSystem.current.IsPointerOverGameObject()){
            // İkinci şart tıklamanın ekrandaki UI elemanlarına mı tıklandığını kontrol ediyor bir nevi. Zıplamak için boş alana tıklanması gerekiyor yani.
            _rigidBody2D.linearVelocity = Vector2.up * velocity;
            _managerAudio.OnPressedForJump();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "ScoreCollider")
        {
            managerGame.UpdateScore();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathArea")
        {
            managerGame.OnGameOver();
        }
   
    }

}
