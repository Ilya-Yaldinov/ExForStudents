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
        this.path = "countrey.txt";
    }

    private string[] ReadFile()
    {
        string[] file = File.ReadAllLines(this.path);
        header = file[0];
        string[] mainInfo = new string[file.Length - 1];
        for(int i = 0; i < mainInfo.Length; i++)
        {
            mainInfo[i] = file[i+1];
        }
        return mainInfo;
    }

    public static void WriteFile(List<FileData> list, string fileName)
    {
        StreamWriter sw = new StreamWriter($"{fileName}.txt");
        sw.WriteLine(header);
        foreach(FileData elem in list)
        {
            sw.WriteLine(elem.ToString());
        }
        sw.Close();
    }

    public static List<FileData> BubbleSortPopulation(List<FileData> list)
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

    public static List<FileData> BubbleSortCountry(List<FileData> list)
    {
        FileData temp;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (needToReOrder(list[i].Country, list[j].Country) == true)
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
            string[] elems = line.Split(';');
            FileData fileData = new FileData(elems[0], elems[1], Convert.ToInt32(elems[2]), Convert.ToInt32(elems[3]), elems[4]);
            CountryList.Add(fileData);
        }
    }
}