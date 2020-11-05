using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraRotationMP : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _maxRange;
    [SerializeField] private float _sensitivity;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _limitY;
    [SerializeField] private LayerMask _cameraLet;
    [SerializeField] private Transform _firefly;

    private float _swipeX, _swipeY;

    private Vector2 _firstLeftPress;
    private Vector2 _secondLeftPress;
    private Vector2 _currentLeftSwipe;

    private void Update()
    {
        _offset = new Vector3(_offset.x, _offset.y, _offset.z);
        _camera.position = _camera.localRotation * _offset + _player.position;

        RaycastHit hit;
        if (Physics.Raycast(_player.position, _maxRange.position - _player.position, out hit, Vector3.Distance(_maxRange.position, _player.position), _cameraLet))
            _camera.position = hit.point;
        else _camera.position = _maxRange.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _firstLeftPress = new Vector2(eventData.position.x, eventData.position.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _secondLeftPress = new Vector2(eventData.position.x, eventData.position.y);
        _currentLeftSwipe = new Vector2(Mathf.Abs(_secondLeftPress.x) - Mathf.Abs(_firstLeftPress.x), Mathf.Abs(_secondLeftPress.y) - Mathf.Abs(_firstLeftPress.y));
        _currentLeftSwipe.Normalize();

        RaycastHit hit;
        if (Physics.Raycast(_player.position, _maxRange.position - _player.position, out hit, Vector3.Distance(_maxRange.position, _player.position), _cameraLet))
            _camera.position = hit.point;
        else _camera.position = _maxRange.position;

        _swipeX = _camera.localEulerAngles.y + _currentLeftSwipe.x * _sensitivity;
        _swipeY += _currentLeftSwipe.y * _sensitivity;
        _swipeY = Mathf.Clamp(_swipeY, -_limitY, _limitY);

        _camera.localEulerAngles = new Vector3(-_swipeY, _swipeX, 0);
        _firefly.localEulerAngles = _camera.localEulerAngles;
        _camera.position = _camera.localRotation * _offset + _player.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}

