using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class GSerialCommunication : MonoBehaviour
{

    SerialPort serialPort= new SerialPort("COM6",9600);
    public StreetLight streetLight;

    void Start()
    {
        streetLight.SetLightOff();
        serialPort.Open();
        
    }
    string temp = "";
    // Update is called once per frame
    void Update()
    {
        if(serialPort.IsOpen)
        {
            try
            {
                string s = serialPort.ReadExisting();
                //StartCoroutine(waiter());

                if(s.Contains("W"))
                {
                    temp = temp + "W";

                }
                if(s.Contains("A"))
                {
                    temp = temp + "A";
                }
                if(s.Contains("S"))
                {
                    temp = temp + "S";
                }
                if(s.Contains("D"))
                {
                    temp = temp + "D";
                }
                if (temp != "")
                {
                    Debug.Log(temp);
                }
                temp = "";
                //if ( == 'O')
                //{
                //    streetLight.SetLightOn();
                //    Debug.Log('O');
                //}
                //if (serialPort.ReadChar() == 'C')
                //{
                //    streetLight.SetLightOff();
                //    Debug.Log('C');
                //}

            }
            catch(System.Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(1);

    }
}
