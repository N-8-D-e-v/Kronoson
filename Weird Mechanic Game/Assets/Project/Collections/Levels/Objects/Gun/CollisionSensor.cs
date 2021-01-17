using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class CollisionSensor : MonoBehaviour
{
    //Public Fields
    public int Overlaps {private set; get;} = 0;

    private void OnCollisionEnter2D(Collision2D _col) => Overlaps ++;

    private void OnCollisionExit2D(Collision2D _col) => Overlaps --;

    private void OnTriggerEnter2D(Collider2D _col) => Overlaps ++;

    private void OnTriggerExit2D(Collider2D _col) => Overlaps --;

    protected bool Colliding()
    {
        return Overlaps > 0;
    }
}
