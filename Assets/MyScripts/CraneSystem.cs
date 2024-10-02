using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraneSystem : MonoBehaviour
{
    public GameObject TowerCrane;
    public GameObject Trolley;
    public GameObject TrolleyNearLimit;
    public GameObject TrolleyFarLimit;
    public GameObject Cable;

    public Slider trolleySlider;

    [Range(0, 1)]
    public float trolleyPosition;

    private Vector3 initialNearLimitOffset;
    private Vector3 initialFarLimitOffset;

    private void Start()
    {
        //TowerCrane offet calculations.
        initialNearLimitOffset = TrolleyNearLimit.transform.position - TowerCrane.transform.position;
        initialFarLimitOffset = TrolleyFarLimit.transform.position - TowerCrane.transform.position;

        //calls for the slider's values and adds a "listener" to convey the information to the code.
        if (trolleySlider != null)
        {
            trolleySlider.onValueChanged.AddListener(OnSliderValueChanged);
            trolleySlider.value = trolleyPosition;
        }
    }

    private void Update()
    {
        
        UpdateLimits();

        
        MoveTrolley();

        
        MoveCable();

        
        RotateTrolley();
        RotateCable();
    }

    private void MoveTrolley()
    {
        Vector3 startPosition = TrolleyNearLimit.transform.position;
        Vector3 endPosition = TrolleyFarLimit.transform.position;

        Trolley.transform.position = Vector3.Lerp(startPosition, endPosition, trolleyPosition);
    }

    private void MoveCable()
    {
        Vector3 cablePosition = Trolley.transform.position;
        cablePosition.y -= 1.0f;
        Cable.transform.position = cablePosition;
    }

    private void UpdateLimits()
    {
        TrolleyNearLimit.transform.position = TowerCrane.transform.position + TowerCrane.transform.TransformVector(initialNearLimitOffset);
        TrolleyFarLimit.transform.position = TowerCrane.transform.position + TowerCrane.transform.TransformVector(initialFarLimitOffset);

        TrolleyNearLimit.transform.rotation = TowerCrane.transform.rotation;
        TrolleyFarLimit.transform.rotation = TowerCrane.transform.rotation;
    }

    private void RotateTrolley()
    {
        //Trolley rotates alongside the Tower
        Trolley.transform.rotation = TowerCrane.transform.rotation;
    }

    private void RotateCable()
    {
        //Cable rotates alongside the Tower
        Cable.transform.rotation = TowerCrane.transform.rotation;
    }

    //slider value's change changes the position of the trolley
    private void OnSliderValueChanged(float value)
    {
        trolleyPosition = value;
    }
}
