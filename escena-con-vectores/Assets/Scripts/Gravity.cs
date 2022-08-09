using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]Transform target;
    
    [SerializeField]float movementSpeed = 1f;
    
    [SerializeField]float gravityRadius = 3f;
    void Start()
    {
        
    }

   
    void Update()
    {
        GravityMovement();
    }

    private void GravityMovement()
    {
        Vector3 direction = (target.position + new Vector3(0, 1f, 0) - transform.position);
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direction);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionObjetivo, movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * gravityRadius * Time.deltaTime);
    }
}
