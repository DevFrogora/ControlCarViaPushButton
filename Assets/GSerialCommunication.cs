using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class GSerialCommunication : MonoBehaviour
{

    SerialPort serialPort = new SerialPort("COM6", 9600);
    public StreetLight streetLight;

    void Start()
    {
        streetLight.SetLightOff();
        serialPort.ReadTimeout = 20;
        serialPort.Open();
        StartCoroutine(Read_SerialPort());


    }
    string temp = "";
    string s = "";
    // Update is called once per frame
    //void Update()
    //{
    //    if (serialPort.IsOpen)
    //    {
    //        try
    //        {
    //            s = serialPort.ReadExisting();
    //            if (s.Contains("W"))
    //            {
    //                temp = temp + "W";

    //            }
    //            if (s.Contains("A"))
    //            {
    //                temp = temp + "A";
    //            }
    //            if (s.Contains("S"))
    //            {
    //                temp = temp + "S";
    //            }
    //            if (s.Contains("D"))
    //            {
    //                temp = temp + "D";
    //            }
    //            if (temp != "")
    //            {
    //                Debug.Log(temp);
    //            }
    //            temp = "";

    //        }
    //        catch (System.Exception e)
    //        {
    //            Debug.Log(e);
    //        }
    //    }
    //}


    IEnumerator Read_SerialPort()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(1/10);
        if (serialPort.IsOpen)
        {
            try
            {
                s = serialPort.ReadLine();
                if (s.Contains("W"))
                {
                    temp = temp + "W";

                }
                if (s.Contains("A"))
                {
                    temp = temp + "A";
                }
                if (s.Contains("S"))
                {
                    temp = temp + "S";
                }
                if (s.Contains("D"))
                {
                    temp = temp + "D";
                }
                if (temp != "")
                {
                    Debug.Log(temp);
                }
                temp = "";

            }
            catch (System.Exception e)
            {
                //Debug.Log(e);
            }
        }
        StartCoroutine(Read_SerialPort());
    }
}
