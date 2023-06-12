using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NukeBag : MonoBehaviour
{
    private int _number;

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            OnNumberOfNukeChanged?.Invoke(_number);
        }
    }

    public UnityEvent<int> OnNumberOfNukeChanged;

    public void UseNuke()
    {
        if (Number <= 0) return;

        Number--;

        Enemy[] enemies = Object.FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.GetDamage(9999999f);
        }
        
    }

}
