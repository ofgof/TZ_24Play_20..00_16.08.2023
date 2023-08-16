using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _chunkLenght;
    [SerializeField] private List<GameObject> _chunkPrefabs;
    private int _chunkCount;
    public void Init()
    {
        for(int i  = 0; i < 5; i++)
        {
            SpawnChunk();
        }
    }
    
    private void SpawnChunk()
    {
        var chunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Count)]);
        chunk.transform.position = _chunkCount * _chunkLenght * Vector3.forward;
        _chunkCount++;
    }
}
