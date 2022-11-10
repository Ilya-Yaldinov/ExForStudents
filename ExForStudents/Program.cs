using System.Globalization;

public class Program
{
    public static void Main()
    {
        Task task = new Task();
        task.StartOfProgram();
    }
}

public class Task
{
    private List<FileData> countryList;
    private List<FileData> continentList = new List<FileData>();
    private List<FileData> notSelectedContinentList = new List<FileData>();

    public Task()
    {
        FileWork file = new FileWork();
        file.FileToList();
        this.countryList = file.CountryList;
    }

    public void StartOfProgram()
    {
        string continent = ContinentChoise();
        DivideContinentToLists(continent);
        var list = SelectedContinentSort();
        string fileName = FileNameInput();
        FileWork.WriteFile(continentList, fileName);
        char firstLetter = FirstLetterOfCapital();
    }

    private string ContinentChoise()
    {
        string continent;
        do
        {
            Console.Write("Пожалуйста выберите название континент для сортировка: ");
            continent = Console.ReadLine();
        } while (!IsChoiseCorrect(continent));
        return continent;
    }

    private void DivideContinentToLists(string continent)
    {
        foreach(FileData country in this.countryList)
        {
            if(country.Continent == continent) this.continentList.Add(country);
            else this.notSelectedContinentList.Add(country);
        }
    }

    private List<FileData> SelectedContinentSort()
    {
        FileData temp;
        for (int i = 0; i < continentList.Count; i++)
        {
            for (int j = i + 1; j < continentList.Count; j++)
            {
                if (continentList[i].Population > continentList[j].Population)
                {
                    temp = continentList[i];
                    continentList[i] = continentList[j];
                    continentList[j] = temp;
                }
            }
        }
        return continentList;
    }

    private bool IsChoiseCorrect(string continent)
    {
        foreach(FileData country in this.countryList)
        {
            if(country.Continent == continent) return true;
        }
        WrongChoise(continent);
        return false;
    }

    private string FileNameInput()
    {
        string fileName = null;
        do
        {
            Console.Clear();
            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();
        } while (fileName == null);
        return fileName;
    }

    private char FirstLetterOfCapital()
    {
        string letter = null;
        do
        {
            Console.Clear();
            Console.Write("Введите первую букву столицы: ");
            letter = Console.ReadLine();
        } while (letter == "" || letter.Length > 1 || int.TryParse(letter, out int i));
        return letter.ToCharArray()[0];
    }

    private void WrongChoise(string continent)
    {
        Console.Clear();
        Console.WriteLine($"Выбранного континента {continent} не существует.");
    }
}