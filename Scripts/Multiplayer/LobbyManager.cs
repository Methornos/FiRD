using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _lobbyPanel;
    [SerializeField] private InputField _nick;
    [SerializeField] private Text _connectingText;
    [SerializeField] private Text _creatingText;
    [SerializeField] private Text _roomName;

    private string _roomCode;

    private Rooms _rooms;

    public void FirstInitialize(Rooms rooms)
    {
        _rooms = rooms;
    }

    public void ShowLobby()
    {
        if (!string.IsNullOrEmpty(_nick.text))
        {
            if (_lobbyPanel.activeSelf == false)
            {
                PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
                PhotonNetwork.LocalPlayer.NickName = MasterManager.GameSettings.Nickname;
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.ConnectUsingSettings();
                _connectingText.gameObject.SetActive(true);
                StartCoroutine("Connecting");
            }
            else
            {
                PhotonNetwork.Disconnect();
            }
        }
    }

    public void CreateRoom()
    {
        if(!string.IsNullOrEmpty(_roomName.text))
        {
            PhotonNetwork.JoinOrCreateRoom(_roomName.text, new RoomOptions { MaxPlayers = 10, PlayerTtl = 10, EmptyRoomTtl = 30 }, TypedLobby.Default);
            _creatingText.gameObject.SetActive(true);
            StartCoroutine("Creating");
        }
    }

    public override void OnCreatedRoom()
    {
        _rooms.CurrentRoom.Show();
        Debug.Log(PhotonNetwork.CurrentRoom.Name + " is current room name.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room or name is taken.");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " left the room.");
        _rooms.CurrentRoom.Hide();
        _rooms.CreateOrJoinRoom.Show();
    }

    public override void OnJoinedRoom()
    {
        _connectingText.gameObject.SetActive(false);
        _creatingText.gameObject.SetActive(false);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " joinned to the room.");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        _connectingText.gameObject.SetActive(false);
        _creatingText.gameObject.SetActive(false);
        Debug.Log("Incorrect room code!");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " connected to master");
        _connectingText.gameObject.SetActive(false);
        _lobbyPanel.SetActive(!_lobbyPanel.activeSelf);

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " disconnected from master");
        _lobbyPanel.SetActive(!_lobbyPanel.activeSelf);
    }

    public void ChangeNickname()
    {
        MasterManager.GameSettings.SetName(EngLettersCheck(_nick.text));
    }

    private IEnumerator Connecting()
    {
        _connectingText.text = "Connecting";
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 3; i++)
        {
            _connectingText.text += ".";
            yield return new WaitForSeconds(0.5f);
        }

        if (_connectingText.gameObject.activeSelf == true)
            StartCoroutine("Connecting");
    }

    private IEnumerator Creating()
    {
        _creatingText.text = "Creating";
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 3; i++)
        {
            _creatingText.text += ".";
            yield return new WaitForSeconds(0.5f);
        }

        if (_creatingText.gameObject.activeSelf == true)
            StartCoroutine("Creating");
    }

    public string EngLettersCheck(string nick)
    {
        string filteredNick = "";

        foreach(char c in nick)
        {
            if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9')
                filteredNick += c;
        }

        _nick.text = filteredNick;

        return filteredNick;
    }
}
