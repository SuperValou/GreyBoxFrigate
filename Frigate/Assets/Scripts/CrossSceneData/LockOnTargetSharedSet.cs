using Assets.Scripts.Players.LockOns;
using UnityEngine;

namespace Assets.Scripts.CrossSceneData
{
    [CreateAssetMenu(fileName = nameof(LockOnTargetSharedSet), menuName = "CrossSceneObjects/" + nameof(LockOnTargetSharedSet))]
    public class LockOnTargetSharedSet : SharedSet<LockOnTarget>
    {
    }
}