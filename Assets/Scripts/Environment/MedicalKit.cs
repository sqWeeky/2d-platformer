using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [SerializeField] private int _extraHealth = 20;

    public MedicalKit()
        => ExtraHealth = _extraHealth;

    public int ExtraHealth { get; private set; }
}