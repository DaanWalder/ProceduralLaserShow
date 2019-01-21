using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phyllotaxis : MonoBehaviour {
    public AudioListener _audioListener;
    private Material _trailMat;
    public Color _trailColor;

    public float _scale;
    public Slider _degree;
    public int _numberStart;
    public int _stepSize;
    public int _maxIteration;

    public bool _useLerping;
    private bool _isLerping;
    private Vector3 _startPosition, _endposition;
    private float _lerpPostimer, _lerpPosSpeed;
    public Vector2 _lerpPosSpeedMinMax;
    public AnimationCurve _lerpPosAnimCurve;
    public int _lerpPosBand;

    private int _number;
    private int _currentIteration;
    private TrailRenderer _trailRenderer;
    private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(number);
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    private Vector2 _phyllotaxisPosition;

    private bool _forward;
    public bool _repeat, _invert;

    public bool _useScaleAnimation, _useScaleCurve;
    public Vector2 _scaleAnimMinMax;
    public AnimationCurve _scaleAnimCurve;
    public float _scaleAnimSpeed;
    public int _scaleBand;
    private float _scaleTimer, _currentScale;

    void SetLerpPosition()
    {
        _phyllotaxisPosition = CalculatePhyllotaxis(_degree.value, _currentScale, _number);
        _startPosition = this.transform.localPosition;
        _endposition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
    }

    void Awake()
    {
        _currentScale = _scale;
        _forward = true;
        /*_trailRenderer = GetComponent<TrailRenderer>();
        _trailMat = new Material(_trailRenderer.material);
        _trailMat.SetColor("_TintColor", _trailColor);
        _trailRenderer.material = _trailMat;*/
        _number = _numberStart;
        transform.localPosition = CalculatePhyllotaxis(_degree.value, _currentScale, _number);
        if (_useLerping)
        {
            _isLerping = true;
            SetLerpPosition();
        }
    }

    private void Update()
    {
        if(_useScaleAnimation)
        {
            if (_useScaleCurve)
            {
                _scaleTimer += (_scaleAnimSpeed * _audioListener._audioBand[_scaleBand]) * Time.deltaTime;
                if (_scaleTimer >= 1)
                {
                    _scaleTimer -= 1;
                }
                _currentScale = Mathf.Lerp(_scaleAnimMinMax.x, _scaleAnimMinMax.y, _scaleAnimCurve.Evaluate(_scaleTimer));
            }
            else
            {
                _currentScale = Mathf.Lerp(_scaleAnimMinMax.x, _scaleAnimMinMax.y, _audioListener._audioBand[_scaleBand]);
            }
        }
        if (_useLerping)
        {
            if (_isLerping)
            {
                _lerpPosSpeed = Mathf.Lerp(_lerpPosSpeedMinMax.x, _lerpPosSpeedMinMax.y, _lerpPosAnimCurve.Evaluate(_audioListener._audioBand[_lerpPosBand]));
                _lerpPostimer += Time.deltaTime * _lerpPosSpeed;
                transform.localPosition = Vector3.Lerp(_startPosition, _endposition, Mathf.Clamp01(_lerpPostimer));
                if (_lerpPostimer >= 1)
                {
                    _lerpPostimer -= 1;
                    if (_forward)
                    {
                        _number += _stepSize;
                        _currentIteration++;
                    }
                    else
                    {
                        _number -= _stepSize;
                        _currentIteration--;
                    }
                    if ((_currentIteration > 0) && (_currentIteration < _maxIteration))
                    {
                        SetLerpPosition();
                    }
                    else
                    {
                        if (_repeat)
                        {
                            if (_invert)
                            {
                                _forward = !_forward;
                                SetLerpPosition();
                            }
                            else
                            {
                                _number = _numberStart;
                                _currentIteration = 0;
                                SetLerpPosition();
                            }
                        }
                        else
                        {
                            _isLerping = false;
                        }
                    }
                }
            }
        }
        if (!_useLerping)
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree.value, _currentScale, _number);
            transform.localPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }
    }
}
