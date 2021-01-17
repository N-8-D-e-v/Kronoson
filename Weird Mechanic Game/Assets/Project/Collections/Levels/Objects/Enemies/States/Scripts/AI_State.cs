using UnityEngine;

public abstract class AI_State : MonoBehaviour
{
    public virtual void LateAwake()
    {
        //OVERRIDE THIS IF NECESSARY
    }
    
    public abstract bool Condition();

    public abstract void Behaviour();
}
