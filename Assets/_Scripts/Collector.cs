using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public static Action<GameObject> OnCollect;
    public static Action OnLose;

    private void OnTriggerEnter(Collider other)
    {
        var collectableObject = other.gameObject.GetComponent<ICollectable>();
        collectableObject?.Collect();

        Debug.Log(other.gameObject.name);
        var chunkEnd = other.gameObject.GetComponent<ChunkEnd>();
        if (chunkEnd != null)
        {
            Debug.Log("OnCrossChunk");
            GameManager.OnCrossChunk?.Invoke();
        }
    }
}
