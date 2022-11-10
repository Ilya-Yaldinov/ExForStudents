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

    public static List<FileData> BubbleSortInt(List<FileData> list)
    {
        FileData temp;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i].Population > list[j].Population)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
        return list;
    }

    public static List<FileData> BubbleSortString(List<FileData> list)
    {
        FileData temp;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (needToReOrder(list[i].Name, list[j].Name) == true)
                { 
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
        return list;
    }

    private static bool needToReOrder(string s1, string s2)
    {
        for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
        {
            if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
            if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
        }
        return false;
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