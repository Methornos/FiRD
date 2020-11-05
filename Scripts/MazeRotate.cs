using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRotate : MonoBehaviour
{
    [SerializeField] private Light _light;

    private float _switchTime = 1f;
    private Color _colorA = Color.white;
    private Color _colorB = Color.black;
    private bool _toggle;
    private IEnumerator _switchCoroutine;

    private void Start()
    {
        SwitchColor();
    }

    private void Update()
    {
        transform.Rotate(0, 0.1f, 0, Space.Self);
    }

    private void SwitchColor()
    {
        _toggle = !_toggle;
        if(_switchCoroutine != null)
            StopCoroutine(_switchCoroutine);
        if (_toggle)
            _switchCoroutine = TransitionColor(_switchTime, _colorA, _colorB);
        else
            _switchCoroutine = TransitionColor(_switchTime, _colorB, _colorA);
        StartCoroutine(_switchCoroutine);
    }

    private IEnumerator TransitionColor(float time, Color colorA, Color colorB)
    {
        float Timer = 0;
        while (Timer < time)
        {
            _light.color = Color.Lerp(colorA, colorB, Timer / time);
            yield return null;
            Timer += Time.deltaTime * 0.1f;
        }
        _light.color = colorB;

        SwitchColor();
    }
}
