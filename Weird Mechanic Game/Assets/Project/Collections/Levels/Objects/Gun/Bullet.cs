using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Destroy
    [SerializeField] private float destroyTime;
    
    private void Awake() => Destroy(gameObject, destroyTime);
    
    private void OnCollisionEnter2D(Collision2D _col) => Destroy(gameObject);
}
