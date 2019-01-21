using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhylloTunnel : MonoBehaviour {
    public Transform _tunnel;
    public AudioListener _audioListener;
    public float _camerDistance;
    private float _privateTunnelSpeed;
    public Slider _tunnelSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _privateTunnelSpeed += Time.deltaTime * (_tunnelSpeed.value * _audioListener._AmplitudeBuffer);
        _tunnel.position = new Vector3(_tunnel.position.x, _tunnel.position.y, _tunnel.position.z + _privateTunnelSpeed);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, _tunnel.position.z + _camerDistance);
    }
}
