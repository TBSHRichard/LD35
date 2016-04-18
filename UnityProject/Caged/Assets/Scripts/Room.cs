using UnityEngine;

public class Room : MonoBehaviour {
    public Block[] blocks;

    /*
        The Player has entered the room, set up the Blocks.
    */
    public void EnterRoom(Player player)
    {
        if (player.form == AnimalForm.Human)
        {
            UnlockBlocks();
        }
    }

    /*
        The Player has exited, reset and lock all Blocks.
    */
    public void ExitRoom()
    {
        foreach (Block block in blocks)
        {
            if (block != null)
            {
                block.ResetBlock();
                block.LockBlock();
            }
        }
    }

    /*
        Unlock all the blocks in the Room.
    */
    public void UnlockBlocks()
    {
        foreach (Block block in blocks)
        {
            if (block != null)
            {
                block.UnlockBLock();
            }
        }
    }

    /*
        Lock all the blocks in the Room.
    */
    public void LockBlocks()
    {
        foreach (Block block in blocks)
        {
            if (block != null)
            {
                block.LockBlock();
            }
        }
    }
}
