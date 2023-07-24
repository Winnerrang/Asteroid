using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NukeBag : MonoBehaviour
{
    private int _number;
    private AudioSource m_audioSource;

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

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    public void UseNuke()
    {
        if (Number <= 0) return;

        Number--;

        Enemy[] enemies = Object.FindObjectsOfType<Enemy>();
        
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsDie)
                enemy.Die();
        }
        m_audioSource.time = 0f;
        m_audioSource.Play();
    }

}
