using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootPoint; // Punto desde donde se dispara el proyectil
    public float shootCooldown = 0.5f; // Tiempo entre disparos

    private float lastShootTime;
    private bool facingRight = true;

    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonUp(0) && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            Vector2 shootDirection = facingRight ? Vector2.right : Vector2.left;
            projectileScript.SetDirection(shootDirection);
        }
    }

    // Método para cambiar la dirección en la que está mirando el player
    public void Flip(bool isFacingRight)
    {
        facingRight = isFacingRight;
    }
}
