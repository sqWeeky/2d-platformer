using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [SerializeField] private int _extraHealth = 20;

    public int GetHealth()
    {
        return _extraHealth;
    }
}