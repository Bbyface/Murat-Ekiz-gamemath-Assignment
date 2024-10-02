using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableExtender : MonoBehaviour
{
    public Slider scaleSlider;
    public float minScale = 0.3f;
    public float maxScale = 1.88f;
    
    void Start()
    {
        scaleSlider.value = minScale;
        scaleSlider.maxValue = maxScale;

        //this listener is a product of AI, I didn't know how to get the slider to work but now I do! :D
        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
    }
}
