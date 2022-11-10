public class FileWork
{
    public List<FileData> CountryList = new List<FileData>();
    private string path;
    private static string header;

    public FileWork(string path )
    {
        this.path = path;
    }

    public FileWork()
    {
        this.path = "people.txt";
    }

    private string[] ReadFile()
    {
        string[] file = File.ReadAllLines(this.path);
        header = file[0];
        return file.Skip(1).ToArray();
    }

    public static void WriteFile(List<FileData> list, string fileName)
    {
        StreamWriter sw = new StreamWriter($"{fileName}.txt");
        sw.WriteLine(header);
        list.ForEach(x => sw.WriteLine(x.ToString()));
        sw.Close();
    }

    public void FileToList()
    {
        string[] file = ReadFile();
        foreach( string line in file)
        {
            FileData fileData = new FileData();
            string[] elems = line.Split(';');
            fileData.Name = elems[0];
            fileData.Capital = elems[1];
            fileData.Square = Convert.ToInt32(elems[2]);
            fileData.Population = Convert.ToInt32(elems[3]);
            fileData.Continent = elems[4];
            CountryList.Add(fileData);
        }
    }
}