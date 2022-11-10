public class FileData
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public int Square { get; set; }
    public int Population { get; set; } 
    public string Continent { get; set; }

    public override string ToString()
    {
        return this.Name + ';' + this.Capital + ';' + this.Square + ';' + this.Population + ';' + this.Continent;
    }
}