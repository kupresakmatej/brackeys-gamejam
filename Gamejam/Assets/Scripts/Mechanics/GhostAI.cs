using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] movementPoints;

    private GameObject itemToMoveTo;

    [SerializeField]
    private float ghostSpeed;

    void Start()
    {
        StartCoroutine(MoveToPoint());
    }

    GameObject GetMovePoint()
    {
        int randomIndex = Random.Range(0, movementPoints.Length);

        itemToMoveTo = movementPoints[randomIndex];

        return itemToMoveTo;
    }

    IEnumerator RestartMovement()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(MoveToPoint());
    }

    IEnumerator MoveToPoint()
    {
        GameObject desiredPosition = GetMovePoint();

        transform.LookAt(new Vector3(desiredPosition.transform.position.x, this.transform.position.y, desiredPosition.transform.position.z));

        float time = 0f;

        while(true)
        {
            time += Time.deltaTime;

            this.transform.position = Vector3.MoveTowards(this.transform.position, desiredPosition.transform.position, ghostSpeed * time);

            if (Mathf.Approximately(transform.position.x, desiredPosition.transform.position.x) || Mathf.Approximately(transform.position.z, desiredPosition.transform.position.z))
            {
                StartCoroutine(RestartMovement());
                yield break;
            }
            yield return null;
        }
    }
}
