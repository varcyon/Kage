using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    
    [SerializeField] GameObject [] enemiesSpawners;
    [SerializeField] GameObject Behemoth;

    void Start()
    {
        InvokeRepeating("Spawn",30f,30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        int location = UnityEngine.Random.Range(0, enemiesSpawners.Length-1);
        Instantiate(Behemoth,new Vector3(enemiesSpawners[location].transform.position.x,enemiesSpawners[location].transform.position.y,0) , Quaternion.identity);
    }
}
