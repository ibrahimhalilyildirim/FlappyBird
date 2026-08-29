using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
    public GameObject Pipes;
    public Bird birdScript;
    public float low_height = -0.24f;
    public float high_height = 0.887f;
    void Start()
    {
        StartCoroutine(PipeSpawn());        
    }
    public IEnumerator PipeSpawn()
    {
        while (birdScript.isDead == false)
        {
            Instantiate(Pipes, new Vector3(3, Random.Range(low_height, high_height), 0), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);



        }
    }
}
