using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balas : MonoBehaviour
{

    public float speed = 5f;
    public float timeLife = 3f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, timeLife);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(speed * targetVector * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.CompareTag("Enemy")){

            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

    private void IncreaseScore(){

        Player.SCORE++;
        Debug.Log(Player.SCORE);
        ActualizarPuntos();

    }

    private void ActualizarPuntos(){

        GameObject point = GameObject.FindGameObjectWithTag("UI");
        point.GetComponent<Text>().text = "Puntuación: " + Player.SCORE;

    }
}
