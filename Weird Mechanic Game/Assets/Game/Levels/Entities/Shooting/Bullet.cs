using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Destroy
    [SerializeField] private float destroyTime = 2f;
    
    private void Awake() => Destroy(gameObject, destroyTime);
    
    private void OnTriggerEnter2D(Collider2D _col) => Destroy(gameObject);
}
