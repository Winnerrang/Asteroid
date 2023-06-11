using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePowerUp : MonoBehaviour, IPowerUp

{
    public void PickUp()
    {
        GameManager.Instance.NukeBagInstance.Number++;
        Destroy(gameObject);
    }

}
