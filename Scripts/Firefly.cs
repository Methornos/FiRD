using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _fireflySphere;

    private void Update()
    {
        transform.position = new Vector3(_player.position.x, 2.5f, _player.position.z);
        _fireflySphere.position = transform.position;
    }
}
