using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnPorMin = 30f;
    public float dificutad = 1f;
    public float x;
    public float timeLife = 4f;

    private float timeSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > timeSpawn){

            timeSpawn = Time.time + 60 / spawnPorMin;

            //añadir dificultad
            spawnPorMin += dificutad;

            float rand = Random.Range(-x, x);
            Vector2 spawnPosition = new Vector2(rand, 10f);
            GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(asteroid, timeLife);
        }
        
    }
}
