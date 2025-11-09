using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _changeTime = 0.25f;
    [SerializeField] private SpriteRenderer _targetRenderer;
    [SerializeField] private Health _health;

    private Color _originalColor;
    private Coroutine _coroutine;

    private void Awake()
    {
        _originalColor = _targetRenderer.color;
    }

    private void OnEnable()
    {
        _health.HitReceived += ChangeColor;
    }

    private void OnDisable()
    {
        _health.HitReceived -= ChangeColor;
    }

    public void ChangeColor()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _targetRenderer.color = _originalColor;
        }

        _coroutine = StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        if (_changeTime <= 0)
            yield break;

        if (_targetRenderer == null)
            yield break;

        var wait = new WaitForSeconds(_changeTime);

        _targetRenderer.color = Color.red;

        yield return wait;

        _targetRenderer.color = _originalColor;
    }
}
