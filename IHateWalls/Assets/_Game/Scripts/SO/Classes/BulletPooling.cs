using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(BulletPooling), menuName = ("Scriptables/" + nameof(BulletPooling)))]
    public class BulletPooling : PoolingBase<BulletBase>
    {

    }
}