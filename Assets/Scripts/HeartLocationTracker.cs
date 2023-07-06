using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLocationTracker : MonoBehaviour
{
    [SerializeField] private GameObject heartObject;
    [SerializeField] private float speed;
    [SerializeField] private float rotationModifier;

    private void FixedUpdate()
    {
        Vector3 vectorToTarget = heartObject.transform.position - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}
