using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool isDead;
    [Header("Movement Settings")]
    [SerializeField] private float velocity = 1f;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    public GameManager managerGame;
    
    void Update()
    {   //GetMouseButtonDown 1 kez input alır. GetMouseButton basılı tutulduğu sürece input alır.
        if(Input.GetMouseButtonDown(0)){
            _rigidBody2D.linearVelocity = Vector2.up * velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "ScoreCollider")
        {
            managerGame.UpdateScore();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
       if(collision.gameObject.tag == "DeathArea")
        {
            Time.timeScale = 0;
        }
    }
}
