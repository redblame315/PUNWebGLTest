using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager instance = null;
    GameObject m_RoomPrefabObj;
    [SerializeField]
    RectTransform m_ContentView;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_RoomPrefabObj = Resources.Load("Prefabs/RoomItem") as GameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.LogError("OnRoomListUpdate" + roomList.Count.ToString());
        m_ContentView.sizeDelta = new Vector2(20 + roomList.Count * 120 , m_ContentView.sizeDelta.y);
        for(int i = 0; i < roomList.Count; i++)
        {
            GameObject roomItemObj = Instantiate(m_RoomPrefabObj) as GameObject;
            roomItemObj.transform.parent = m_ContentView;
            roomItemObj.transform.localScale = Vector3.one;
            RectTransform rectTransform = roomItemObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(20 + i * 120, -20);
            RoomItem roomItem = roomItemObj.GetComponent<RoomItem>();
            roomItem.SetLoomName(roomList[i].Name);
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.LogError("OnJoinedLobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.LogError("OnJoinedRoom");
        PhotonNetwork.LoadLevel("Game");
    }

    public void CreateRoomButtonClicked()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2});
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.LogError("OnEnable");
        PhotonNetwork.JoinLobby();
        //Debug.LogError("AddCallbackTarget");
        //PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.LogError("OnDisable");
        //Debug.LogError("RemoveCallbackTarget");
        //PhotonNetwork.RemoveCallbackTarget(this);
    }
}
