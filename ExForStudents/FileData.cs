public class FileData
{
    public string Country { get; set; }
    public string Capital { get; set; }
    public int Square { get; set; }
    public int Population { get; set; } 
    public string Continent { get; set; }

    public FileData(string country, string capital, int square, int population, string continent)
    {
        Country = country;
        Capital = capital;
        Square = square;
        Population = population;
        Continent = continent;
    }

    public override string ToString()
    {
        return this.Country + ';' + this.Capital + ';' + this.Square + ';' + this.Population + ';' + this.Continent;
    }
}