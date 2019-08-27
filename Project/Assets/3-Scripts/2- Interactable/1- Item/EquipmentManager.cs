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

    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquipment; // items we currently have equipped
    SkinnedMeshRenderer[] currentMesh; // graphics of current equipment


    public delegate void OnEquipmentChanged(Equipment newItem, Equipment equippedItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMesh = new SkinnedMeshRenderer[numSlots];
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

        // Insert the item into slot
        currentEquipment[slotIndex] = newItem; 
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMesh[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if(currentMesh[slotIndex] != null)
            {
                Destroy(currentMesh[slotIndex].gameObject);
            }
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

