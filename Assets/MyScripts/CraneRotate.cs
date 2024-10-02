using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;

public class CraneRotate : MonoBehaviour
{
    public float rotationSpeed = 5f; //I use a slow turn because it'll simulate real cranes better
    public HoldableButton clockwiseButton;
    public HoldableButton counterclockwiseButton;

    void Update()
    {
        if (clockwiseButton != null && clockwiseButton.IsHeldDown)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (counterclockwiseButton != null && counterclockwiseButton.IsHeldDown)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }

}
