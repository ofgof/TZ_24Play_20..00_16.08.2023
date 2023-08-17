using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Constants")]
public class GlobalConstants : ScriptableObject
{
    [SerializeField] private float _cubeCollectionDuration;
    public float CubeCollectionDuration => _cubeCollectionDuration;

    [SerializeField] private float _maxPositionDifference;
    public float MaxPositionDifference => _maxPositionDifference;

}
