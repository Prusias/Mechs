namespace MechAndSandals.Abilities
{
    internal class Cooldown : IAbility
    {
        private int v;

        public Cooldown(int v)
        {
            this.v = v;
        }
    }
}