namespace Game.Runtime.Enemies
{
    public struct EntityDamaged
    {
        public EntityDamaged(Entity entity, bool entityKilled, int damageTaken)
        {
            Entity = entity;
            EntityKilled = entityKilled;
            DamageTaken = damageTaken;
        }

        public Entity Entity;
        public bool EntityKilled;
        public int DamageTaken;
    }
}