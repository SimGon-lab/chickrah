using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("chickling");
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.transform.position;
        var cameraPos = transform.position;

        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y;

        transform.position = cameraPos;
    }
}
