using UnityEngine;

public class CollissionDrawer : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
