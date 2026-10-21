using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class PollEcho : MonoBehaviour
{
    // Socket(套接字)
    private Socket socket;

    // GUI
    public InputField inputField;
    public Text text;

    string recvStr = "";

    // 点击连接按钮
    public void Connection()
    {
        // Socket
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // Connect
        socket.BeginConnect("127.0.0.1", 8888, ConnectCallback, socket);
    }
    
       public void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // EndConn
            Socket socket = (Socket)ar.AsyncState;
            socket.EndConnect(ar);
            Debug.Log("Socket Connect Success");
        }
        catch (SocketException ex)
        {
            Debug.Log("Socket Connect fail" + ex);
        }

    }
    // 点击发送按钮
    public void Send()
    {
        // Send
        string sendStr = inputField.text;
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr);
        socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, socket);
    }

    // Send回调
    public void SendCallback(IAsyncResult ar)
    {
        try
        {
            Socket socket = (Socket)ar.AsyncState;
            int count = socket.EndSend(ar);
            Debug.Log("Socket Send succ" + count);
        }
        catch (SocketException ex)
        {
            Debug.Log("Socket Send fail" + ex);
        }
    }

    public void Update()
    {
        if (socket == null)
        {
            return;
        }

        if (socket.Poll(0, SelectMode.SelectRead))
        {
            byte[] readBuff = new byte[1024];
            int count = socket.Receive(readBuff);
            recvStr = recvStr + "\n" +  System.Text.Encoding.Default.GetString(readBuff, 0, count);
            text.text = recvStr;
            Debug.Log("send su" + recvStr);
        }
        
    }
   
}
