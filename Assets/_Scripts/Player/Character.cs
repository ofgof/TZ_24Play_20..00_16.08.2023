using UnityEngine;

public class Character : MonoBehaviour, IKillable
{
    [SerializeField] private Animator _animator;
    private void Start()
    {
        SetRigidbody(true);
        SetCollider(false);
    }
    public void Kill()
    {
        GameManager.OnGameEnd?.Invoke();
        Debug.Log($"[{name}] Kill");
        SetRigidbody(false);
        SetCollider(true);
        _animator.enabled = false;
    }

    private void SetRigidbody(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    private void SetCollider(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (var collider in colliders)
        {
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
}
