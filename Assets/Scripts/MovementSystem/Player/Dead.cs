using UnityEngine;
using System;
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
        Destroy(gameObject);
        _message.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Activation()
    {
        _animator.SetTrigger(_stay);
        _message.enabled = true;
        Invoke("DeadObject", _delay);
    }
}