namespace DO;

[Serializable]
/// <summary>
/// מחלקת שגיאה עבור ת.ז שגויה
/// </summary>
public class DalNotExistException : Exception
{
    public DalNotExistException(string meesage) : base(meesage) { }
}

/// <summary>
/// מחלקת שגיאה עבור ת.ז קיימת
/// </summary>
public class DalExsistException : Exception
{
    public DalExsistException(string meesage) : base(meesage) { }
}


