public class DodgerAttributes
{
    private int currentHealth;
    private int maxHealth;
    private int currentScore;
    public DodgerAttributes()
    {
        maxHealth = 3;
        currentHealth = 3;
        currentScore = 0;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetCurrentHealth(int value)
    {
        currentHealth = value;
    }

    public void SetCurrentScore(int value)
    {
        currentScore = value;
    }
}