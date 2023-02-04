using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(0, 1000) % 3;
        if(PlayerManager.LocalPlayerInstance == null)
            PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(random, 0, random), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
