using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _force;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _firefly;

    private float _swipeX, _swipeY;

    private float _tweakFactor = 0.5f;

    private Vector2 _firstRightPress;
    private Vector2 _secondRightPress;
    private Vector2 _currentRightSwipe;

    private void Update()
    {
        _firefly.position = new Vector3(_player.position.x, 2.5f, _player.position.z); ;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _firstRightPress = new Vector2(eventData.position.x, eventData.position.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void Up()
    {
        _playerRigidbody.AddForce(_camera.forward * _force);
    }

    public void Down()
    {
        _playerRigidbody.AddForce(-_camera.forward * _force);
    }

    public void Left()
    {
        _playerRigidbody.AddForce(-_camera.right * _force);
    }

    public void Right()
    {
        _playerRigidbody.AddForce(_camera.right * _force);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _secondRightPress = new Vector2(eventData.position.x, eventData.position.y);
        _currentRightSwipe = new Vector2(Mathf.Abs(_secondRightPress.x) - Mathf.Abs(_firstRightPress.x), Mathf.Abs(_secondRightPress.y) - Mathf.Abs(_firstRightPress.y));
        _currentRightSwipe.Normalize();

        if (_currentRightSwipe.y > 0 && _currentRightSwipe.x > 0 - _tweakFactor && _currentRightSwipe.x < _tweakFactor)
        {
            
        }
        else if (_currentRightSwipe.y < 0 && _currentRightSwipe.x > 0 - _tweakFactor && _currentRightSwipe.x < _tweakFactor)
        {
            
        }
        else if (_currentRightSwipe.x < 0 && _currentRightSwipe.y > 0 - _tweakFactor && _currentRightSwipe.x < _tweakFactor)
        {
            
        }
        else if (_currentRightSwipe.x > 0 && _currentRightSwipe.y > 0 - _tweakFactor && _currentRightSwipe.x < _tweakFactor)
        {
            
        }
    }
}
