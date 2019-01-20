using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTriangle : MonoBehaviour {
    public AudioListener _audioListener;
    private float _rotateSpeed;
    public float _rotationSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _rotateSpeed += Time.deltaTime * (_rotationSpeed * _audioListener._Amplitude);
        transform.Rotate( 0, 0, _rotateSpeed*Time.deltaTime, Space.World);
    }
}
