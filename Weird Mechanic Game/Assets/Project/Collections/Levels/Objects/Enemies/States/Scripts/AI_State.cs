using UnityEngine;

public abstract class AI_State : MonoBehaviour
{
    //Public Fields
    public Rigidbody2D Rigidbody {set; get;}
    public Transform Transform {set; get;}
    
    public virtual void LateAwake()
    {
        //OVERRIDE THIS IF NECESSARY
    }
    
    public abstract bool Condition();

    public abstract void Behaviour();
}
