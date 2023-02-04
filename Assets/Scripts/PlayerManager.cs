using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public static PlayerManager LocalPlayerInstance = null;
    CameraWork cameraWork;
    float v = 0;
    float h = 0;
    [SerializeField]
    float moveSpeed = 3;
    [SerializeField]
    float rotationSpeed = 10;

    private void Awake()
    {
        if(photonView.IsMine)
            LocalPlayerInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraWork = gameObject.GetComponent<CameraWork>();

        if(photonView.IsMine)
        {
            Debug.LogError("CameraWork");
            cameraWork.OnStartFollowing();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine && PhotonNetwork.IsConnected)
        {
            InputHandle();
        }

        if(h != 0 || v != 0)
        {
            Vector3 forward = v * transform.forward + h * transform.right;
            forward.Normalize();

            Quaternion to = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, to, Time.deltaTime * rotationSpeed);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        
    }

    public void InputHandle()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
    }
}
