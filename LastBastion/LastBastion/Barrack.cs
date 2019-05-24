namespace LastBastion
{
    public class Barrack : Building
    {
        uint _rank = 1;

        public Barrack(
            float posX, 
            float posY, 
            uint lifePoints, 
            uint maxLifePoints, 
            uint armor, 
            uint rank,
            uint woodCost, 
            uint foodCost, 
            uint stoneCost, 
            uint villagerCost,
            Map context)
            : base(
                  posX, 
                  posY, 
                  lifePoints,
                  maxLifePoints, 
                  armor,
                  rank,
                  woodCost,
                  foodCost,
                  stoneCost,
                  villagerCost, 
                  context,"Barrack","test")
        {

        }

        public void Upgrade()
        {
            if(_rank < 3)
            {
                _rank++;
                IncHealth();
                IncreaseArmor();
            }
        }
    }
}