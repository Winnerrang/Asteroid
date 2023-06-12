using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerUp : PowerUp
{
    public override void PickUp()
    {
        GameManager.Instance.GunPowerUpControllerInstance.EquipPower();
        Destroy(gameObject);
    }
}
