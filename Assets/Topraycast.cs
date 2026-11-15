
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalRaycastController : MonoBehaviour
{
    [SerializeField] private float range = 100f;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float impactForce = 10f;
    [SerializeField] private LayerMask hitLayers;



    private void Awake()
    {
        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        RaycastHit hit;

        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 0.5f);

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range, hitLayers))
        {
            if (hit.collider.CompareTag("Goal"))
            {
                Debug.Log("Gol Oldu!");

                Rigidbody rb = GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForceAtPosition(firePoint.forward * impactForce, transform.position, ForceMode.Impulse);
                }
            }
        }
    }

}
