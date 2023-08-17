using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float _maxPositionDifference;
    private void Start()
    {
        _maxPositionDifference = GameManager.Instance.GlobalConstants.MaxPositionDifference;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var stopableObject = collision.gameObject.GetComponent<IStopable>();
        if(stopableObject != null)
        {
            var directionToCube = collision.gameObject.transform.position - transform.position;
            if (directionToCube.y > _maxPositionDifference) return;

            stopableObject.Stop();
        }

        var killableObject = collision.gameObject.GetComponent<IKillable>();
        if (killableObject != null)
        {
            var directionToCharacter = collision.gameObject.transform.position - transform.position;
            if (directionToCharacter.y > _maxPositionDifference) return;

            killableObject.Kill();
        }
    }
}
