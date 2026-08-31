using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;


public class Bird : MonoBehaviour
{
    public bool isDead;
    [Header("Movement Settings")]
    [SerializeField] private float velocity = 1f;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private GameObject _gameOverUI;
    private bool _isGameOverPopupActive = false;
    public GameManager managerGame;
    public event Action<GameState> OnGameStateChanged;

    void Update()
    {   //GetMouseButtonDown 1 kez input alır. GetMouseButton basılı tutulduğu sürece input alır.
        if(managerGame.GetGameState() == GameState.Play && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            // İkinci şart tıklamanın ekrandaki UI elemanlarına mı tıklandığını kontrol ediyor bir nevi. Zıplamak için boş alana tıklanması gerekiyor yani.
            _rigidBody2D.linearVelocity = Vector2.up * velocity;
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
