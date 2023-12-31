using UnityEngine;

public class CollectableCube : MonoBehaviour, ICollectable, IStopable
{
    [SerializeField] private bool _isCollected = false;

    public void Collect()
    {
        if (_isCollected) return;
        _isCollected = true;
        Collector.OnCollect?.Invoke(gameObject);
    }

    public void Stop()
    {
        Collector.OnLose?.Invoke();
        transform.parent = null;
        Destroy(this);
    }
}
