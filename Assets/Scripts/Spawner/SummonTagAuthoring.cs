using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SummonTagAuthoring : MonoBehaviour
{
    
}

public class SummonTagBaker : Baker<SummonTagAuthoring>
{
    public override void Bake(SummonTagAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new SummonTagComponent());
    }
}