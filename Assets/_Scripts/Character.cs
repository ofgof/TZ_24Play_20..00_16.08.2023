using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IKillable
{
    public void Kill()
    {
        GameManager.OnGameEnd?.Invoke();
        Debug.Log($"[{name}] Kill");
    }
}
