using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;

    protected abstract void Shoot();
}
