using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CableExtender : MonoBehaviour
{
    public Slider scaleSlider;
    public float minScale = 0.3f;
    public float maxScale = 1.88f;

    public GameObject concrete; // Reference to the Concrete GameObject
    private HookPicksUpConcrete hookPicksUpConcrete; // Reference to the HookPicksUpConcrete script
    private bool isScalingUp = false; // To track if scaling is currently happening

    void Start()
    {
        scaleSlider.value = minScale;
        scaleSlider.maxValue = maxScale;

        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Get the HookPicksUpConcrete component from the concrete GameObject
        hookPicksUpConcrete = concrete.GetComponent<HookPicksUpConcrete>();
    }

    void Update()
    {
        // Check if the positions match (X and Z)
        if (Mathf.Approximately(transform.position.x, concrete.transform.position.x) &&
            Mathf.Approximately(transform.position.z, concrete.transform.position.z))
        {
            // Start scaling up if not already scaling up
            if (!isScalingUp)
            {
                StartCoroutine(ScaleUp());
            }
        }
        else
        {
            // If the positions don't match, reset scaling
            if (isScalingUp)
            {
                StopCoroutine(ScaleUp());
                isScalingUp = false;
                StartCoroutine(ScaleToMin());
            }
        }
    }

    private IEnumerator ScaleUp()
    {
        isScalingUp = true;

        // Scale up to maxScale
        while (transform.localScale.y < maxScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.MoveTowards(transform.localScale.y, maxScale, Time.deltaTime), transform.localScale.z);
            yield return null;
        }

        // Wait until isAttached is true
        while (hookPicksUpConcrete != null && !hookPicksUpConcrete.isAttached)
        {
            yield return null;
        }

        // Scale down to minScale
        StartCoroutine(ScaleToMin());
    }

    private IEnumerator ScaleToMin()
    {
        // Scale down to minScale
        while (transform.localScale.y > minScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.MoveTowards(transform.localScale.y, minScale, Time.deltaTime), transform.localScale.z);
            yield return null;
        }

        isScalingUp = false; // Reset scaling state
    }

    private void OnSliderValueChanged(float value)
    {
        transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
    }
}
