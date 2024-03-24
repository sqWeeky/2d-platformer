using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private float _timer;
    private float _time;
    private bool _isActived;

    public void Activation(float timer)
    {
        _timer = timer;
        _time = 0;
        _isActived = true;
    }

    private void Update()
    {
        if (_isActived)
        {
            if (_time < _timer)
            {
                _time += Time.deltaTime;
                _icon.fillAmount = _time / _timer;
            }
            else
            {
                _isActived = false;
                _time = 0;
                _icon.fillAmount = 1;
            }
        }
    }
}