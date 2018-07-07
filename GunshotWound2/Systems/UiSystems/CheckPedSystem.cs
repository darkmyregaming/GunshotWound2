﻿using GunshotWoundEcs.Components.UiComponents;
using GunshotWoundEcs.Components.WoundComponents;
using LeopotamGroup.Ecs;

namespace GunshotWoundEcs.Systems.UiSystems
{
    [EcsInject]
    public class CheckPedSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private EcsFilter<CheckPedComponent> _components;
        private EcsFilter<BleedingComponent> _wounds;
        
        public void Run()
        {
            GunshotWoundScript.LastSystem = nameof(CheckPedSystem);
            for (int i = 0; i < _components.EntitiesCount; i++)
            {
                int pedEntity = _components.Components1[i].PedEntity;
                var woundedPed = _ecsWorld.GetComponent<WoundedPedComponent>(pedEntity);

                if (woundedPed != null)
                {
                    var painPercent = woundedPed.PainMeter / woundedPed.MaximalPain;
                    if (painPercent > 0.8f)
                    {
                        SendMessage($"~s~Pain Level: ~r~{painPercent * 100f:0.0}%~s~");
                    }
                    else if (painPercent > 0.6f)
                    {
                        SendMessage($"~s~Pain Level: ~o~{painPercent * 100f:0.0}%~s~");
                    }
                    else if (painPercent > 0.3f)
                    {
                        SendMessage($"~s~Pain Level: ~y~{painPercent * 100f:0.0}%~s~");
                    }
                    else
                    {
                        SendMessage($"~s~Pain Level: ~g~{painPercent * 100f:0.0}%~s~");
                    }

                    string healthInfo = "";
                    if (woundedPed.DamagedParts > 0)
                    {
                        healthInfo += "Damaged body parts: ";
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.NERVES_DAMAGED))
                        {
                            healthInfo += "~r~Nerves ";
                        }
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.HEART_DAMAGED))
                        {
                            healthInfo += "~r~Heart ";
                        }
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.LUNGS_DAMAGED))
                        {
                            healthInfo += "~r~Lungs ";
                        }
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.STOMACH_DAMAGED))
                        {
                            healthInfo += "~r~Stomach ";
                        }
                    
                        if(woundedPed.DamagedParts.HasFlag(DamageTypes.GUTS_DAMAGED))
                        {
                            healthInfo += "~r~Guts ";
                        }
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.ARMS_DAMAGED))
                        {
                            healthInfo += "~r~Arms ";
                        }
                    
                        if (woundedPed.DamagedParts.HasFlag(DamageTypes.LEGS_DAMAGED))
                        {
                            healthInfo += "~r~Legs ";
                        }

                        if (!string.IsNullOrEmpty(healthInfo))
                        {
                            SendMessage(healthInfo + "~s~");
                        }
                        
                    }
                }

                string wounds = "";
                for (int woundIndex = 0; woundIndex < _wounds.EntitiesCount; woundIndex++)
                {
                    var wound = _wounds.Components1[woundIndex];
                    if(pedEntity != wound.PedEntity) continue;
                    
                    if (wound.BleedSeverity > 3f)
                    {
                        wounds += $"~r~{wound.Name}~s~\n";
                    }
                    else if (wound.BleedSeverity > 2f)
                    {
                        wounds += $"~o~{wound.Name}~s~\n";
                    }
                    else if (wound.BleedSeverity > 1f)
                    {
                        wounds += $"~y~{wound.Name}\n";
                    }
                    else
                    {
                        wounds += $"~s~{wound.Name}\n";
                    }
                }

                if (string.IsNullOrEmpty(wounds)) wounds = "~g~You have no wounds~s~";
                SendMessage($"Wounds:\n{wounds}");
                
                _ecsWorld.RemoveEntity(_components.Entities[i]);
            }
        }

        private void SendMessage(string message, NotifyLevels level = NotifyLevels.COMMON)
        {
            var notification = _ecsWorld.CreateEntityWith<NotificationComponent>();
            notification.Level = level;
            notification.StringToShow = message;
        }
    }
}