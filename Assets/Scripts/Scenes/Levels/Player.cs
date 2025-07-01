using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Collider2D _movementArea;
    [SerializeField] private RectTransform _parentBounds;

    [SerializeField] private GameObject _up;
    [SerializeField] private List<ObstraclesLine> _obstacleLines;
    [SerializeField] private GameObject _down;

    private RectTransform _rectTransform;
    private Camera _mainCamera;
    private AudioService _audioService;
    private bool _isInterract = true;
    private Vector2 _offset;

    public event Action loseEvent;


    public void Deactivate()
    {
        _isInterract = false;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        for (int i = 0; i < _obstacleLines.Count; i++)
        {
            if (gameObject.transform.position.y < _obstacleLines[i].ObstaclePosition.y)
            {
                _parentBounds.transform.SetParent(_obstacleLines[i].transform, true);
            }
            
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isInterract)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out _offset
            );
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isInterract)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _parentBounds,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localCursor
            ))
            {
                Vector2 newPos = localCursor - _offset;

                newPos.x = Mathf.Clamp(
                    newPos.x,
                    _parentBounds.rect.xMin + _rectTransform.rect.width / 2,
                    _parentBounds.rect.xMax - _rectTransform.rect.width / 2
                );
                newPos.y = Mathf.Clamp(
                    newPos.y,
                    _parentBounds.rect.yMin + _rectTransform.rect.height / 2,
                    _parentBounds.rect.yMax - _rectTransform.rect.height / 2
                );

                _rectTransform.anchoredPosition = newPos;
            }
        }
    }

    private bool IsTouchOnObject(Touch touch)
    {
        Vector2 touchWorldPos = _mainCamera.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(touchWorldPos, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }

    private Vector2 GetClampedPosition(Vector2 targetPosition)
    {
        if (_movementArea != null)
        {
            Bounds bounds = _movementArea.bounds;
            return new Vector2(
                Mathf.Clamp(targetPosition.x, bounds.min.x, bounds.max.x),
                Mathf.Clamp(targetPosition.y, bounds.min.y, bounds.max.y)
            );
        }
        return targetPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) {
            loseEvent?.Invoke();
            _isInterract = false;
        }
    }
}
