using UnityEngine;

public class Take : MonoBehaviour
{
    public bool IsTake { get; private set; }

    private void Start()
    {
        IsTake = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Knife knife))
        {
            IsTake = true;
            Destroy(knife);
        }
    }
}