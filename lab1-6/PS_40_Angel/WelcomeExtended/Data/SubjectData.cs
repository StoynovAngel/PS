using Welcome.Model;

namespace WelcomeExtended.Data;

public class SubjectData
{
    private List<Subject> subjects;
    private int _nextId;

    public SubjectData()
    {
        subjects = new List<Subject>();
        _nextId = 0;
    }
}