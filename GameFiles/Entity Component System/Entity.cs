namespace Basic2DGame.GameFiles.Entity_Component_System;

public struct Entity
{
    private static uint _id = 0;
    public uint ID { get; private set; }
    public Entity()
    {
        ID = _id++;
    }
}