using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    public event Action<int> ThiefEnter;
    public event Action<int> ThiefExit;
    
    private void Awake() => 
        _alarmSystem = FindObjectOfType<AlarmSystem>();

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief)) 
            ThiefEnter?.Invoke(1);
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief)) 
            ThiefExit?.Invoke(-1);
    }
}