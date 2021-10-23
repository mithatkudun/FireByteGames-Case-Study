using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderForYLS : MonoBehaviour
{
    public GameObject YLS;
    public Slider slider;
    private float previousValue;

    void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        this.previousValue = this.slider.value;
    }

    void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.YLS.transform.Rotate(Vector3.right * delta * 74);
        this.previousValue = value;
    }
}
