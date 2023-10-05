using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    float rotationspeed = 5f;

    private void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationspeed));
    }
}
