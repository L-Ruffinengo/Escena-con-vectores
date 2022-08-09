using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    float speed = 2f;

    float cameraAxisX = 0f; //variable que tomará el valor Input del mouse en el Eje X.
    
    [SerializeField]
    float speedToLook = 1f; //variable que define la velocidad de rotación
    void Start()
    {

    }


    void Update()
    {
        RotatePlayer();
        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        }
    }
    void Movement(Vector3 direction) //Método para el movimiento del Player que tiene en cuenta rotación
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void RotatePlayer() //Método para rotar el Player con el Mouse
    {
        cameraAxisX += Input.GetAxis("Mouse X"); //El valor de la variable toma como valor el movimiento del mouse en el eje X
        Quaternion rotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speedToLook * Time.deltaTime); //Lerp lee la rotación actual, la rotación objetivo y la velocidad de interpolación
    }
}
