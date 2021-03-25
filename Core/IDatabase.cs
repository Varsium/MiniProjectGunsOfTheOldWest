namespace GunsOfTheOldWest.Core
{
    public interface IDatabase
    {
        int Bullets { get; set; }
        bool GameWon { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        int Number { get; set; }
        void Initalize();
    }
}