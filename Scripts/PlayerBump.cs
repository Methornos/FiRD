using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBump : MonoBehaviour
{
    [SerializeField] private AudioSource _knockSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
            _knockSource.Play();
    }
}
