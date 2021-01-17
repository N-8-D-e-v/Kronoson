using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class CollisionSensor : MonoBehaviour
{
    //Public Fields
    public int Overlaps {private set; get;} = 0;

    //Tag
    private const string BLOCKING = "Blocking";

    private void OnCollisionEnter2D(Collision2D _col)
    {
        if (_col.collider.CompareTag(BLOCKING))
            Overlaps ++;
    }

    private void OnCollisionExit2D(Collision2D _col)
    {
        if (_col.collider.CompareTag(BLOCKING))
            Overlaps --;
    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.CompareTag(BLOCKING))
            Overlaps ++;
    }

    private void OnTriggerExit2D(Collider2D _col)
    {
        if (_col.CompareTag(BLOCKING))
            Overlaps --;
    }

    protected bool Colliding()
    {
        return Overlaps > 0;
    }
}
