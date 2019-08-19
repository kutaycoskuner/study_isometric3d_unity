using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment equippedItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot; 
        Equipment equippedItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            equippedItem = currentEquipment[slotIndex];
            inventory.Add(equippedItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, equippedItem);
        }

        currentEquipment[slotIndex] = newItem; 
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment equippedItem = currentEquipment[slotIndex];
            inventory.Add(equippedItem);

            currentEquipment[slotIndex] = null;

            if(onEquipmentChanged != null)
            {   
                onEquipmentChanged.Invoke(null, equippedItem);
            }
        }
    }

    public void UnequipAll ()
    {
        for(int i=0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
    
    void Update () 
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll(); 
        }
    }
    

}

