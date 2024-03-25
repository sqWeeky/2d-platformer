using UnityEngine;

public class LifeSteal : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Timer _iconTimer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

    private float _damage = 0.2f;
    private float _lifeSteal;
    private float _time;
    private float _timer = 6f;

    private void Start()
    {
        this.gameObject.SetActive(false);
        _lifeSteal = _damage;
        _time = _timer;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            _healthPlayer.Heal(_lifeSteal);
        }
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
            _time = _timer;
        }
    }

    public void Activation()
    {
        _iconTimer.Activation(_timer);
        this.gameObject.SetActive(true);
        _audioSource.PlayOneShot(_clip);
    }
}