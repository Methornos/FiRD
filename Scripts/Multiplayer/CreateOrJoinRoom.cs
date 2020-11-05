using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoom : MonoBehaviour
{
    [SerializeField] private LobbyManager _lobbyManager;
	[SerializeField] private RoomListingMenu _roomListingsMenu;

    private Rooms _rooms;

    public void FirstInitialize(Rooms rooms)
    {
        _rooms = rooms;
        _lobbyManager.FirstInitialize(rooms);
		_roomListingsMenu.FirstInitialize(rooms);
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
