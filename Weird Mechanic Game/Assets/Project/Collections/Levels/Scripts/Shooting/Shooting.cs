using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooting : MonoBehaviour
{
    //Input
    public bool Input_Shoot {set; private get;} = false;

    //Assignables
    private Animator animator;

    //Gun Stats
    [Header("Gun Stats")]
    [SerializeField] private Gun gun;
    private bool canShoot = true;

    //Animation
    private const string SHOOT = "shoot";

    private void Awake() => animator = GetComponent<Animator>();
    
    private void Update()
    {
        if (Input_Shoot && canShoot)
            Shoot();
    }

    private void Shoot()
    {
        animator.Play(SHOOT);
        for (int i = 0; i < gun.Shots; i++)
        {
            Rigidbody2D _bullet = Instantiate(gun.Bullet, gun.GunTip, transform.rotation);
            _bullet.AddForce(transform.up * gun.Range, ForceMode2D.Impulse);
        }
        canShoot = false;
        Invoke(nameof(Reload), gun.FireRate);
    }

    private void Reload() => canShoot = true;
}

[System.Serializable]
public struct Gun
{
    public Rigidbody2D Bullet;
    public Vector3 GunTip;
    public float Range;
    public float FireRate;
    public int Shots;
}
