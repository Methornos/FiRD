using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    private Rooms _rooms;

    public void FirstInitialize(Rooms rooms)
    {
        _rooms = rooms;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
