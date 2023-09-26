using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int SCORE = 0;

    public float thrustForce = 100f;
    public float rotationSpeed = 130f;

    public GameObject disparo, balaPrefab;

    public Vector3 dir;
    private Rigidbody rigid;

    private float limitY;
    private float limitX;

    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody>();

        limitY = Camera.main.orthographicSize + 1;
        limitX = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;

    }

    // Update is called once per fra)me
    void Update()
    {
        //creo un límite en la pantalla y sensación de espacio infinito
        var pos = transform.position;
        if (pos.x > limitX){
            pos.x = -limitX;
        }else if (pos.x < -limitX){
            pos.x = limitX;
        }else if (pos.y > limitY){
            pos.y = -limitY;
        }else if (pos.y < -limitY){
            pos.y = limitY;
        }
        transform.position = pos;

        //asignar movimiento de la nave a las teclas verticales
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        //asignar movimiento de la nave a las teclas horizontales
        float rotacion = Input.GetAxis("Horizontal") * Time.deltaTime;

        dir = transform.right;
        rigid.AddForce(thrustForce * dir * thrust);
        
        //rotar la nave
        transform.Rotate(Vector3.forward, -rotacion * rotationSpeed);

        // si estoy pulsando el espacio disparo balas
        if(Input.GetKeyDown(KeyCode.Space)){

            GameObject bala = Instantiate(balaPrefab, disparo.transform.position, Quaternion.identity);

            //la bala siempre apunta al arma
            Balas balaScript = bala.GetComponent<Balas>();
            balaScript.targetVector = transform.right;
        }
        
    }

    private void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.tag == "Enemy"){

            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else{
            Debug.Log("He colisionado con otra cosa...");
        }

    }

}