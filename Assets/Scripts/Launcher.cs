using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayer = 3;
    [SerializeField]
    GameObject m_ConnectPanelObj;
    [SerializeField]
    GameObject m_LobbyPanelObj;
    [SerializeField]
    TextMeshProUGUI m_ProgressText;
    [SerializeField]
    TMP_InputField m_NickNameInputField;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect()
    {
        string nickName = m_NickNameInputField.text;
        if (string.IsNullOrEmpty(nickName))
        {
            return;
        }
            
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.NickName = nickName;
            PhotonNetwork.ConnectUsingSettings();
            m_ProgressText.text = "Connecting...";
        }
    }

    public void SetVisibleConnectPanel(bool visible)
    {
        m_ConnectPanelObj.SetActive(visible);
    }

    public override void OnConnected()
    {
        Debug.Log("PUN OnConnected Success");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN OnConnectedToMaster Success");
        SetVisibleConnectPanel(false);
        m_LobbyPanelObj.SetActive(true);
        m_ProgressText.text = "";
        gameObject.SetActive(false);
        LobbyManager.instance.gameObject.SetActive(true);
        //PhotonNetwork.LoadLevel("Lobby");
        //SceneManager.LoadSceneAsync("Lobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("PUN OnDisconnected Success");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("PUN OnJoinRoomFailed");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN OnJoinRandomFailed");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinRoom");
    }

    /*public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.LogError("OnRoomListUpdate_Launcher" + roomList.Count.ToString());
        m_ContentView.sizeDelta = new Vector2(20 + roomList.Count * 120, m_ContentView.sizeDelta.y);
        for (int i = 0; i < roomList.Count; i++)
        {
            GameObject roomItemObj = Instantiate(m_RoomPrefabObj) as GameObject;
            roomItemObj.transform.parent = m_ContentView;
            roomItemObj.transform.localScale = Vector3.one;
            RectTransform rectTransform = roomItemObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(20 + i * 120, -20);
            RoomItem roomItem = roomItemObj.GetComponent<RoomItem>();
            roomItem.SetLoomName(roomList[i].Name);
        }
    }*/
}
