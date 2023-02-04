using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class RoomItem : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_LoomLabelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLoomName(string roomName)
    {
        m_LoomLabelText.text = roomName;
    }

    public void RommButtonClicked()
    {
        PhotonNetwork.JoinRoom(m_LoomLabelText.text);
    }
}
