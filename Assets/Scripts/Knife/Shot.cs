using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private GameObject _knife;
    [SerializeField] private Timer _iconTimer;

    private float _timer = 3f;
    private bool _canShot = true;

    private void Start()
    {
        //_iconTimer = GetComponent<Timer>();
    }

    public void Activation()
    {
        if (_canShot)
        {
            _iconTimer.Activation(_timer);
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _canShot = false;
        Instantiate(_knife, _shotPosition.position, transform.rotation);
        yield return new WaitForSeconds(_timer);
        _canShot = true;
    }
}