using UnityEngine;

public class ThrowKnife : MonoBehaviour
{
    [SerializeField] private Transform _throwPosition;
    [SerializeField] private GameObject _knife;    

    public void Activation()
    {
        Instantiate(_knife, _throwPosition.position, transform.rotation);
    }
}
