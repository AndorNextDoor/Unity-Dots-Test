using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Entity targetEntity;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetEntity = GetRandomEntity();
        }
        if (targetEntity != Entity.Null)
        {
            Vector3 followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(targetEntity).Position;
            transform.position = followPosition;
        }
    }

    private Entity GetRandomEntity()
    {
        EntityQuery summonTagEntityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(SummonTagComponent));
        NativeArray<Entity> entityArray = summonTagEntityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);

        if (entityArray.Length > 0)
        {
            return entityArray[Random.Range(0,entityArray.Length)];
        }
        else
        {
            return Entity.Null;
        }
        
    }
}
