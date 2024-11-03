using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public Transform[] patrolPoints; // Array de puntos de patrulla
    public float speed = 2f; // Velocidad de movimiento del enemigo
    private int currentPatrolIndex = 0;

    public float rotationAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (patrolPoints.Length == 0) return;

        Vector3 direction = (patrolPoints[currentPatrolIndex].position - transform.position).normalized;

        // Rotación suave hacia el siguiente punto
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        // Movimiento hacia el punto de patrulla actual
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.1f);
        }
    }
}