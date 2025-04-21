using UnityEngine;
using System;

public interface IAttackable
{
    AttackableBehavior AttackableBehavior { get; set;  }
    public abstract float MaxHealth { get; set; }
    public abstract float CurrentHealth { get; set; }
    public abstract float Damage { get; set; }
    public abstract float Speed { get; set; }
}
