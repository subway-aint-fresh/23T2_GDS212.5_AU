using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCells : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    public Transform followTarget;
    [SerializeField] private float stoppingDistance = 0.10f;

    private void Update()
    {
        if (followTarget != null)
        {
            float distance = Vector2.Distance(transform.position, followTarget.position);

            if (distance > stoppingDistance)
            {
                transform.position = Vector2.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
            }
        }
    }
}
