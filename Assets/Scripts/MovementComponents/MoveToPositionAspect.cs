using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity entity;

    private readonly RefRW<LocalTransform> localTransform;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime)
    {
        float3 direction = math.normalize(targetPosition.ValueRO.value - localTransform.ValueRO.Position);
        localTransform.ValueRW.Position += direction * deltaTime * speed.ValueRO.value;

    }
    
    public void ReachTargetPosition(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = .5f;
        if (math.distancesq(localTransform.ValueRW.Position, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomPosition(randomComponent);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return new float3(
            randomComponent.ValueRW.random.NextFloat(-15, 15f), 0, randomComponent.ValueRW.random.NextFloat(-15, 15f));
    }

}
