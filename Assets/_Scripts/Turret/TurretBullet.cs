using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MyMonoBehaviour
{
    //TODO: just debuging for now

    public GameObject bullet;
    public bool isShooting = false;

    protected void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (this.CanShoot())
        {
            this.bullet.transform.position = Vector3.zero;
            Instantiate(bullet);
        }
    }

    protected virtual bool CanShoot()
    {
        this.isShooting = InputManager.Instance.MouseInput == 1;
        return this.isShooting;
    }
}
