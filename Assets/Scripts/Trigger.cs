using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void Awake() => 
        _alarmSystem = FindObjectOfType<AlarmSystem>();

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief))
            _alarmSystem.AlarmOn();
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief))
            _alarmSystem.AlarmOff();
    }
    
    
}