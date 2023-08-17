using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHolder : MonoBehaviour
{
    [SerializeField] private VFX _VFXConfig;
    [SerializeField] private Dictionary<VFXType, VFXObject> _VFXDict;

    private Camera _camera;
    public void Init()
    {
        _camera = Camera.main;
        _VFXDict = new Dictionary<VFXType, VFXObject>();

        foreach (var vfx in _VFXConfig.VFXList)
        {
            if (_VFXDict.ContainsKey(vfx.type)) continue;
            
            _VFXDict.Add(vfx.type, vfx);
        }

        StartCoroutine(CheckForDelete());
    }
    public GameObject GetVFX(VFXType type)
    {
        return _VFXDict[type].VFX;
    }
    public GameObject SpawnVFX(VFXType type, Vector3 position)
    {
        var vfx = Instantiate(GetVFX(VFXType.CollectVFX), transform);
        vfx.transform.position = position;
        return vfx;
    }
    private IEnumerator CheckForDelete()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            var cameraPosition = _camera.transform.position;
            for(int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).transform;
                if (cameraPosition.z - child.position.z > 10)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
