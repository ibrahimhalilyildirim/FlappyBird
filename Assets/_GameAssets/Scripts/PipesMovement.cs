using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; 
        
    }
    private void Start()
    {
        Destroy(gameObject, 10);
    }
}

