using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float _maxPositionDifferenceCube;
    private float _maxPositionDifferenceCharacter;
    private void Start()
    {
        _maxPositionDifferenceCube = GameManager.Instance.GlobalConstants.MaxPositionDifferenceCube;
        _maxPositionDifferenceCharacter = GameManager.Instance.GlobalConstants.MaxPositionDifferenceCharacter;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var stopableObject = collision.gameObject.GetComponent<IStopable>();
        if(stopableObject != null)
        {
            var directionToCube = collision.gameObject.transform.position - transform.position;
            if (directionToCube.y > _maxPositionDifferenceCube) return;

            stopableObject.Stop();
        }

        var killableObject = collision.gameObject.GetComponent<IKillable>();
        if (killableObject != null)
        {
            var directionToCharacter = collision.gameObject.transform.position - transform.position;
            Debug.Log("directionToCharacter = " + directionToCharacter);
            if (directionToCharacter.y > _maxPositionDifferenceCharacter) return;

            killableObject.Kill();
        }
    }
}
