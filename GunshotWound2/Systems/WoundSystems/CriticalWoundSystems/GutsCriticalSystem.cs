﻿using GunshotWoundEcs.Components.WoundComponents;
using GunshotWoundEcs.Components.WoundComponents.CriticalWoundComponents;
using LeopotamGroup.Ecs;

namespace GunshotWoundEcs.Systems.WoundSystems.CriticalWoundSystems
{
    [EcsInject]
    public class GutsCriticalSystem : BaseCriticalSystem<GutsCritcalComponent>
    {
        public GutsCriticalSystem()
        {
            Damage = DamageTypes.GUTS_DAMAGED;
        }
        
        protected override void ActionForPlayer(WoundedPedComponent pedComponent, int pedEntity)
        {
        }

        protected override void ActionForNpc(WoundedPedComponent pedComponent, int pedEntity)
        {
        }
    }
}