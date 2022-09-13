using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketIO_Client_Test : MonoBehaviour
{
    private SocketIOUnity socket;

    // Start is called before the first frame update
    void Start()
    {
        var uri = new Uri("http://localhost:3000");
        socket = new SocketIOUnity(uri, new SocketIOOptions

        {
            Query = new Dictionary<string, string>
        {
            {"token", "UNITY" }
        }
            ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });
        socket.JsonSerializer = new NewtonsoftJsonSerializer();

    }

    // Update is called once per frame
    void Update()
    {

        socket.On("message", (response) =>
        {
            Debug.Log(response.GetValue());
        });

        if (Input.GetKeyDown(KeyCode.Space))
        {
            socket.Emit("unity", "Unity overall boiiii");
        }

    }
}
