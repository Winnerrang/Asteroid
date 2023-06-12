using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : PowerUp

{
    public override void PickUp()
    {
        GameManager.Instance.NukeBagInstance.Number++;
        Destroy(gameObject);
    }

}
