using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment(s)")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        // equip the item
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        // remove it from the inventory
    }
    
}


public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet};