using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    
    private Coroutine _coroutineAlarmOn;
    private Coroutine _coroutineAlarmOff;

    private void OnDisable()
    {
        if (_coroutineAlarmOn != null)
        {
            StopCoroutine(_coroutineAlarmOn);
        }

        if (_coroutineAlarmOn != null)
        {
            StopCoroutine(_coroutineAlarmOff);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief))
        {
            if (_coroutineAlarmOff != null)
            {
                StopCoroutine(_coroutineAlarmOff);
            }

            if (_alarmSystem != null)
            {
                _coroutineAlarmOn = StartCoroutine(_alarmSystem.AlarmOn());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief))
        {
            if (_coroutineAlarmOn != null)
            {
                StopCoroutine(_coroutineAlarmOn);
            }

            if (_alarmSystem != null)
            {
                _coroutineAlarmOff = StartCoroutine(_alarmSystem.AlarmOff());
            }
        }
    }
    
    
}