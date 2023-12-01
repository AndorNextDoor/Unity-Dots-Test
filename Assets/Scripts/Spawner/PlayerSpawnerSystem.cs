using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery summonEntityQuery = EntityManager.CreateEntityQuery(typeof(SummonTagComponent));
        

        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        SpawnerComponent spawnerComponent = SystemAPI.GetSingleton<SpawnerComponent>();

        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        
        int spawnAmount = spawnerComponent.summonAmount;
        if (summonEntityQuery.CalculateEntityCount() < spawnAmount)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnerComponent.summonPrefab);
            entityCommandBuffer.SetComponent(spawnedEntity,new Speed
            {
                value = randomComponent.ValueRW.random.NextFloat(1f, 5f)
            });
        }
    }
}
