using Assets.Scripts.LoadingSystems.PersistentVariables;
using Assets.Scripts.Players.LockOns;
using UnityEngine;

namespace Assets.Scripts.PersistentData
{
    [CreateAssetMenu(fileName = nameof(LockOnTargetSet), menuName = nameof(Assets) + "/"
                                                                + nameof(PersistentData) + "/" 
                                                                + nameof(LockOnTargetSet))]
    public class LockOnTargetSet : PersistentSet<LockOnTarget>
    {
    }
}