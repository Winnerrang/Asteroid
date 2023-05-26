using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Health
{
    public int _currentHealth;

    public int MaxHealth { get; set; }

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            _currentHealth = Math.Clamp(_currentHealth, 0, MaxHealth);
        }
    }
}

