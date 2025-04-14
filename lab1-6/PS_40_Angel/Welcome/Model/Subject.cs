namespace Welcome.Model;

public class Subject
{
    private int id;
    private string name;
    private int semester;
    private string year;
    
    public virtual int Id { get => id; set => id = value; }
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Year
    {
        get => year;
        set => year = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public int Semester { get => semester; set => semester = value; }
    
    public override string ToString()
    {
        return $"Subject's name: {Name}, Semester: {Semester}, Year: {Year}";
    }

}