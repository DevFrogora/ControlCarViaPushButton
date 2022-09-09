using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarLink : MonoBehaviour
{

    public CarController carController;


    public void CarMovePerformed(Vector2 input)
    {

        carController.CarMovePerf(input);
        Debug.Log(input);
    }

    public void CarMoveCanceled(Vector2 input)
    {

        carController.CarMoveCancel(input);

    }

}
