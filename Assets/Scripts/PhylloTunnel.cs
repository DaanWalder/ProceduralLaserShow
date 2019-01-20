using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhylloTunnel : MonoBehaviour {
    public Transform _tunnel;
    public AudioListener _audioListener;
    public float _tunnelSpeed, _camerDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _tunnelSpeed += Time.deltaTime * (_audioListener._AmplitudeBuffer);
        _tunnel.position = new Vector3(_tunnel.position.x, _tunnel.position.y, _tunnel.position.z + _tunnelSpeed);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, _tunnel.position.z + _camerDistance);
    }
}
