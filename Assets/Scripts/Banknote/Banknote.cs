using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Banknote : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _maxAngleChange;
    [SerializeField] private RectTransform _rectTransform;

    private Vector3 _rotationDirection;
    private bool _isFalling = false;
    private float _initialAngle;
    private Coroutine _coroutine;

    public RectTransform RectTransform => _rectTransform;

    public event Action<Banknote> BanknoteReturn;

    private void Start()
    {
        _rotationDirection = GetRotationDirection();
    }

    private void OnEnable()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(MoveAndFall());
    }

    private void Update()
    {
        if (_isFalling)
        {
            UpdateFalling();
        }

        RotateBanknote();
    }

    private void UpdateFalling()
    {
        MoveBanknote();

        if (IsOutOfScreen())
        {
            BanknoteReturn?.Invoke(this);
            ResetState();
        }
    }

    private void MoveBanknote()
    {
        Vector2 position = GetCurrentPosition();
        position.y -= _moveSpeed * Time.deltaTime;
        _rectTransform.anchoredPosition = position;
    }

    private void RotateBanknote()
    {
        _rectTransform.Rotate(_rotationDirection, _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator MoveAndFall()
    {
        _initialAngle = Random.Range(-_maxAngleChange, _maxAngleChange);
        float targetHeight = GetCurrentPosition().y + _maxHeight;

        while (GetCurrentPosition().y < targetHeight)
        {
            Vector2 position = GetCurrentPosition();
            position.y += _moveSpeed * Time.deltaTime;
            position.x += Mathf.Tan(_initialAngle * Mathf.Deg2Rad) * (_moveSpeed * Time.deltaTime);

            _rectTransform.anchoredPosition = position;

            yield return null;
        }

        _isFalling = true;
        _coroutine = null;
    }

    private Vector3 GetRotationDirection()
    {
        int minNumber = 0;
        int maxNumber = 2;
        int numberCompare = 1;

        return Random.Range(minNumber, maxNumber) < numberCompare ? Vector3.forward : Vector3.back;
    }

    private Vector2 GetCurrentPosition()
    {
        return _rectTransform.anchoredPosition;
    }

    private bool IsOutOfScreen()
    {
        Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, _rectTransform.position);

        bool isOutOfVerticalBounds = screenPosition.y < 0;

        return isOutOfVerticalBounds;
    }

    private void ResetState()
    {
        _isFalling = false;
        _rectTransform.anchoredPosition = Vector2.zero;
        _rectTransform.rotation = Quaternion.identity;
    }
}