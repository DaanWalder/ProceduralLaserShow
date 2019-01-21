using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour {
    public Slider _redSlider;
    public Slider _greenSlider;
    public Slider _blueSlider;
    public Slider _redSliderSecond;
    public Slider _greenSliderSecond;
    public Slider _blueSliderSecond;
    public Material _colorMat;
    public Material _secondColorMat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _colorMat.color = new Color(_redSlider.value, _greenSlider.value, _blueSlider.value, 1);
        _secondColorMat.color = new Color(_redSliderSecond.value, _greenSliderSecond.value, _blueSliderSecond.value, 1);
    }
}
