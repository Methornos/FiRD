using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private string _nickname = "";
    public string Nickname
    {
        get { return _nickname; }
        set { _nickname = value; }
    }
    public void SetName(string nickname)
    {
        this.Nickname = nickname;
    }

    [SerializeField] private string _gameVersion = "0.0";
    public string GameVersion { get { return _gameVersion; } }
}
