
public class GameState 
{
    public int numItemsCollected;
    public int lifes;
    public int totalLifes;
    public int numItems;
    public int points;
    public  GameState(int numItemsCollected, int lifes, int totalLifes, int numItems,int points)
    {
        this.numItemsCollected = numItemsCollected;
        this.lifes = lifes;
        this.numItems = numItems;
        this.totalLifes = totalLifes;
        this.points = points;
    }
    public float GetDamagePercent()
    {
       
        return (totalLifes - lifes) / (float)totalLifes;
    }
}
