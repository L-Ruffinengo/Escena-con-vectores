using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private enum EnemyType
    {
        Stare,
        Chase,
        Coward,
        Track,
    }

    [SerializeField] private EnemyType enemyType;

    [SerializeField] private Transform target;

    [SerializeField] private float speedToLook = 1f;

    [SerializeField] private float movementSpeed = 2f;
    void Start()
    {

    }


    void Update()
    {
        SetEnemyMovement();
    }

    private void SetEnemyMovement()
    {
        switch (enemyType)
        {
            case EnemyType.Stare:
                LookAtPlayer();
                break;
            case EnemyType.Chase:
                ChasePlayer();
                break;
            case EnemyType.Coward:
                CowardEnemy();
                break;
            case EnemyType.Track:
                TrackPlayer();
                break;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = (target.position - transform.position); //Cálculo de la dirección de rotación.
        Quaternion rotacionObjetivo = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacionObjetivo, speedToLook * Time.deltaTime);

    }

    private void ChasePlayer()
    {
        LookAtPlayer();
        Vector3 direction = (target.position - transform.position); //calculo de la dirección de movimiento
        if (direction.magnitude > 2f)//establece una distancia a la cual el enemigo se va a detener
        {
            transform.position += (direction.normalized * movementSpeed * Time.deltaTime);//Se normaliza la magnitud del vector direction para que la velocidad de movimiento sea constante
        }
    }
    private void CowardEnemy()
    {
        LookAtPlayer();
        Vector3 direction = (target.position - transform.position); //calculo de la dirección de movimiento
        if (direction.magnitude < 5f)//establece una distancia a la cual el enemigo comienza a escapar
        {
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);//Se normaliza la magnitud del vector direction para que la velocidad de movimiento sea constante
        }
    }
    private void TrackPlayer()
    {
        LookAtPlayer();
        Vector3 direction = (target.position - transform.position); //calculo de la dirección de movimiento
        if (direction.magnitude < 10f)//establece una distancia a partir de la cual el enemigo comienza a perseguir
        {
            if(direction.magnitude > 1f)
            {
                transform.position += (direction.normalized * movementSpeed * Time.deltaTime);//Se normaliza la magnitud del vector direction para que la velocidad de movimiento sea constante
            }
        }
    }
}
