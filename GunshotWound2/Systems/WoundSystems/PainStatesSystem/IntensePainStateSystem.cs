﻿using GTA;
using GTA.Native;
using GunshotWound2.Components.EffectComponents;
using GunshotWound2.Components.WoundComponents;
using GunshotWound2.Components.WoundComponents.PainStateComponents;
using Leopotam.Ecs;

namespace GunshotWound2.Systems.WoundSystems.PainStatesSystem
{
    [EcsInject]
    public class IntensePainStateSystem : BasePainStateSystem<IntensePainStateComponent>
    {
        public IntensePainStateSystem()
        {
            CurrentState = PainStates.INTENSE;
        }
        
        protected override void ExecuteState(WoundedPedComponent woundedPed, int pedEntity)
        {
            base.ExecuteState(woundedPed, pedEntity);

            SwitchAnimationComponent anim;
            EcsWorld.CreateEntityWith(out anim);
            anim.PedEntity = pedEntity;
            anim.AnimationName = woundedPed.IsPlayer 
                ? Config.Data.PlayerConfig.IntensePainAnim
                : Config.Data.NpcConfig.IntensePainAnim;
            
            if (woundedPed.DamagedParts.HasFlag(DamageTypes.ARMS_DAMAGED)) return;

            var backPercent = 1f - woundedPed.PainMeter / woundedPed.MaximalPain;
            if (woundedPed.IsPlayer)
            {
                Function.Call(Hash._SET_CAM_EFFECT, 2);
            }
            else
            {
                woundedPed.ThisPed.Accuracy = (int) (backPercent * woundedPed.DefaultAccuracy);
            }
        }
    }
}