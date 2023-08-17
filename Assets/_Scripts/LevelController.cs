using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float _chunkLenght;
    [SerializeField] private Transform _mapTransform;
    [SerializeField] private List<GameObject> _chunkPrefabs;

    [SerializeField] protected int _visibleChunks = 3;
    private int _chunkCount = 1;
    public void Init()
    {
        for (int i = 0; i < _visibleChunks; i++)
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
        var chunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Count)], _mapTransform);
        var upVectop = 10f * Vector3.up;
        chunk.transform.position = _chunkCount * _chunkLenght * Vector3.forward - upVectop;
        chunk.transform.DOMoveY(0f, duration);
        _chunkCount++;
        CheckForDelete();
    }
    private void CheckForDelete()
    {
        float visiableChunkPosition = (_chunkCount - _visibleChunks - 2) * _chunkLenght;
        for (int i = 0; i < _mapTransform.childCount; i++)
        {
            var child = _mapTransform.GetChild(i).transform;
            if (child.position.z < visiableChunkPosition)
            {
                Destroy(child.gameObject);
            }
            else
            {
                break;
            }
        }
    }
}
