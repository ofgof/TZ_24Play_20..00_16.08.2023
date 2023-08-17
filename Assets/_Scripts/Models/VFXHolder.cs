using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHolder : MonoBehaviour
{
    [SerializeField] private VFX _VFXConfig;
    [SerializeField] private Dictionary<VFXType, VFXObject> _VFXDict;
    //public Dictionary<VFXType, VFXObject> VFXDict => _VFXDict;
    public void Init()
    {
        _VFXDict = new Dictionary<VFXType, VFXObject>();

        foreach (var vfx in _VFXConfig.VFXList)
        {
            if (_VFXDict.ContainsKey(vfx.type)) continue;
            
            _VFXDict.Add(vfx.type, vfx);
        }
    }
    public GameObject GetVFX(VFXType type)
    {
        return _VFXDict[type].VFX;
    }
}
