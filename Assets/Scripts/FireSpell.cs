using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public static FireSpell Instance;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject outPoint;
    [SerializeField] float speed;
    private void Awake()
    {
        Instance = this;
    }

    public void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, outPoint.transform.position, outPoint.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(outPoint.transform.forward * speed, ForceMode.Impulse);
        bullet.GetComponent<Rigidbody>().AddForce(outPoint.transform.TransformDirection(direction) * speed, ForceMode.Impulse);
    }
}
