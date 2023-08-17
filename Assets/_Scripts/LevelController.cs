using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _chunkLenght;
    [SerializeField] private List<GameObject> _chunkPrefabs;
    private int _chunkCount = 1;
    public void Init()
    {
        for(int i  = 0; i < 3; i++)
        {
            SpawnChunk();
        }
        GameManager.OnCrossChunk += SpawnChunk;
    }
    private void OnDestroy()
    {
        GameManager.OnCrossChunk -= SpawnChunk;
    }
    private void SpawnChunk()
    {
        var duration = 1f;
        var chunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Count)]);
        var upVectop = 10f * Vector3.up;
        chunk.transform.position = _chunkCount * _chunkLenght * Vector3.forward - upVectop;
        chunk.transform.DOMoveY(0f, duration);
        _chunkCount++;
    }
}
