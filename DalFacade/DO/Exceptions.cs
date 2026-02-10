namespace DO;

[Serializable]
/// <summary>
/// מחלקת שגיאה עבור ת.ז שגויה
/// </summary>
public class DalIdNotExistException : Exception
{
    public DalIdNotExistException(string meesage) : base(meesage) { }
    //public DalIdNotExistException(string meesage,Exception innerException) : base(meesage,innerException) { }
}

/// <summary>
/// מחלקת שגיאה עבור ת.ז קיימת
/// </summary>
public class DalIdExsistException : Exception
{
    public DalIdExsistException(string meesage) : base(meesage) { }
}
