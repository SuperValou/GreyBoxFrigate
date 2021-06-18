using Assets.Scripts.LoadingSystems.PersistentVariables;
using Assets.Scripts.Players.LockOns;
using UnityEngine;

namespace Assets.Scripts.PersistentData
{
    [CreateAssetMenu(fileName = nameof(LockOnTargetSharedSet), menuName = nameof(Assets) + "/"
                                                                        + nameof(PersistentData) + "/" 
                                                                        + nameof(LockOnTargetSharedSet))]
    public class LockOnTargetSharedSet : PersistentSet<LockOnTarget>
    {
    }
}