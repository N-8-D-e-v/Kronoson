using UnityEngine;

public abstract class AI_State : MonoBehaviour
{
    //Public Fields
    public Rigidbody2D Rigidbody {set; get;}
    public Transform Transform {set; get;}
    
    public abstract void LateAwake();
    
    public abstract bool Condition();

    public abstract void Behaviour();
}
