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
        var list = FileWork.BubbleSortInt(continentList);
        string fileName = FileNameInput();
        FileWork.WriteFile(list, fileName);
        char firstLetter = FirstLetterOfCapital();
        var selectedCountreyByCapital = SelectedCapitalsToList(firstLetter);
        list = FileWork.BubbleSortString(selectedCountreyByCapital);
        fileName = FileNameInput();
        FileWork.WriteFile(list, fileName);

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
        return char.ToLower(letter.ToCharArray()[0]);
    }

    private List<FileData> SelectedCapitalsToList(char firstLetter)
    {
        List<FileData> selectedCountreyByCapital = new List<FileData>();
        foreach(FileData fileData in this.notSelectedContinentList)
        {
            if (char.ToLower(fileData.Capital[0]) == firstLetter) selectedCountreyByCapital.Add(fileData);
        }
        return selectedCountreyByCapital;
    }

    private void WrongChoise(string continent)
    {
        Console.Clear();
        Console.WriteLine($"Выбранного континента {continent} не существует.");
    }
}