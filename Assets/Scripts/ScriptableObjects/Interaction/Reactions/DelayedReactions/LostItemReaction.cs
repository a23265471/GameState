using UnityEngine;
public class LostItemReaction : DelayedReaction
{
    public Item item;
    private Inventory inventory;

    protected override void SpecificInit()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

	protected override void ImmediateReaction()
	{
        inventory.RemoveItem(item);
	}
}
