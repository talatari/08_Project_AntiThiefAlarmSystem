using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _coroutineAlarmOn;
    private Coroutine _coroutineAlarmOff;
    private int _speedVolume = 2;
    
    private void Start() => _audioSource = GetComponent<AudioSource>();

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Thief thief))
        {
            if (_coroutineAlarmOff != null)
            {
                StopCoroutine(_coroutineAlarmOff);
            }
            
            _coroutineAlarmOn = StartCoroutine(AlarmOn());
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
            
            _coroutineAlarmOff = StartCoroutine(AlarmOff());
        }
    }

    private IEnumerator AlarmOn()
    {
        _audioSource.Play();
        
        while (_audioSource.volume < 1)
        {
            _audioSource.volume += Time.deltaTime / _speedVolume;
            
            yield return null;
        }
    }
    
    private IEnumerator AlarmOff()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= Time.deltaTime / _speedVolume;
            
            yield return null;
        }
        
        _audioSource.Stop();
    }
}