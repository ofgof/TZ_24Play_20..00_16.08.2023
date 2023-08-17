using System;
using System.Collections.Generic;
using UnityEngine;

public enum VFXType { CollectVFX, CollectPlusOne }

[Serializable]
public class VFXObject
{
    public VFXType type;
    public GameObject VFX;
}
[CreateAssetMenu(menuName = "Config/VFXObjects")]
public class VFX : ScriptableObject
{
    [SerializeField] private List<VFXObject> _VFXList;
    public List<VFXObject> VFXList => _VFXList;
}
