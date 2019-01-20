using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanner : MonoBehaviour
{
    public AudioListener _audioListener;
    public GameObject _scannerObject1, _scannerObject2, _scannerObject3, _scannerObject4;
    private Material _scannerMaterial;
   //public Color _scannerColor;
    private MeshRenderer _scannerRenderer;
    private Vector3 _startPosition, _endPosition;
    private float _scannerTimer, _scannerSpeed;

    private void Start()
    {
        _startPosition = new Vector3(0, -4.39f, 0.36f);
        _endPosition = new Vector3(0, 0, 0.36f);
       /* _scannerRenderer = _scannerObject1.GetComponent<MeshRenderer>();
        _scannerMaterial = new Material(Shader.Find("Standard"));
        _scannerMaterial.color = _scannerColor;
        _scannerRenderer.material = _scannerMaterial;*/
    }

    private void Update()
    {
        _scannerTimer += Time.deltaTime * (_audioListener._AmplitudeBuffer);
        _scannerObject1.transform.position = new Vector3(0, Mathf.PingPong(_scannerTimer, 4f), -0.36f);
        _scannerObject2.transform.position = new Vector3(0, -(Mathf.PingPong(_scannerTimer, 4f)), -0.36f);
        _scannerObject3.transform.position = new Vector3(Mathf.PingPong(_scannerTimer, 7.2f), 0, -0.36f);
        _scannerObject4.transform.position = new Vector3(-Mathf.PingPong(_scannerTimer, 7.2f), 0, -0.36f);
    }
    }
