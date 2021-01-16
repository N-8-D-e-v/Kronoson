using UnityEngine;

public class Player : MonoBehaviour
{
    //Singleton
    private static Player Instance;

    //Components
    public static Transform Transform;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        Transform = transform;
    }
}
