using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Dead : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _message;

    private float _delay = 3f;
    private string _stay = "Dead";

    private void DeadObject()
    {
        Debug.Log("Вошел в деад");
        
        Debug.Log(_message.enabled);
        _animator.SetTrigger(_stay);
        Destroy(gameObject);
        _message.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Activation()
    {
        _message.enabled = true;
        Invoke("DeadObject", _delay);
    }
}