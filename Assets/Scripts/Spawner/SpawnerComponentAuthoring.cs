using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerComponentAuthoring : MonoBehaviour
{
    public GameObject summonPrefab;
    public int summonAmount;


}


public class SpawnerBaker : Baker<SpawnerComponentAuthoring>
{
    public override void Bake(SpawnerComponentAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new SpawnerComponent{

            summonAmount = authoring.summonAmount,
            summonPrefab = GetEntity(authoring.summonPrefab, TransformUsageFlags.Dynamic),
        });
    }
}
