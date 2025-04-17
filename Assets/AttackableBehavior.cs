using Unity;
using UnityEngine;

public abstract class AttackableBehavior : MonoBehaviour
{
    //CONSIDER USING THIS INTO A STATE MACHINE?
    public abstract void IdleBehavior();
    public abstract void AttackingBehavior();
}