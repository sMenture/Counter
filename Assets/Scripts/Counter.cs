using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private const float DelayTimer = 0.5f;

    [SerializeField] private MouseClickInput _mouseClickInput;
    [SerializeField] private int _currentTime;

    public event UnityAction<int> CountUpdated;
    
    private Coroutine _countingCoroutine;
    private bool _isCounting => _countingCoroutine != null;

    private void Start()
    {
        _currentTime = 0;
        CountUpdated?.Invoke(_currentTime);
    }

    private void OnEnable()
    {
        _mouseClickInput.Clicked += ToggleCounting;
    }

    private void OnDisable()
    {
        _mouseClickInput.Clicked -= ToggleCounting;
    }

    private void ToggleCounting()
    {
        if (_isCounting)
            StopCounting();
        else
            StartCounting();
    }

    private void StartCounting()
    {
        _countingCoroutine = StartCoroutine(TimeCounter(DelayTimer));
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator TimeCounter(float delay)
    {
        var wait = new WaitForSeconds(delay);

        do
        {
            _currentTime++;
            CountUpdated?.Invoke(_currentTime);

            yield return wait;

        } while (_isCounting);
    }
}
