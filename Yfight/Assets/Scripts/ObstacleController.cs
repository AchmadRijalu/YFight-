using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] obstacle;
    
    [SerializeField] float secondSpawn = 3f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    void Start()
    {
        StartCoroutine(ObstacleSpawn());
        

    }


   
    IEnumerator ObstacleSpawn()
    {
        while (true)
        {
            var spawn = Random.Range(minTras, maxTras);
            var position = new Vector3(spawn, transform.position.y);
            GameObject gameObject = Instantiate(obstacle[Random.Range(0, obstacle.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            
                Destroy(gameObject);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
}
