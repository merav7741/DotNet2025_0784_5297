
using System.Text.Json.Serialization;

namespace BO;

[Serializable]
public class BlIdExistsException : Exception
{
    public BlIdExistsException(string? message) : base(message) { }
    public BlIdExistsException(string message, Exception innerExeption) : base(message, innerExeption) { }

}
[Serializable]
public class BlNotfoundObjectWithThisFilterException : Exception
{
    public BlNotfoundObjectWithThisFilterException(string? message) : base(message) { }
    public BlNotfoundObjectWithThisFilterException(string? message, Exception innerException) : base(message, innerException) { }

}

[Serializable]
public class BLIdNotFoundException : Exception
{
    public BLIdNotFoundException(string messege) : base(messege) { }
    public BLIdNotFoundException(string messege, Exception innerException) : base(messege, innerException) { }
}
[Serializable]

public class FailedToDeleteFolder : Exception
{
    public FailedToDeleteFolder(string messege) : base(messege) { }
    //public FailedToDeleteFolder(string messege,Exception innerException) : base(messege, innerException) { }

}
[Serializable]
public class BLThereIsNotEnoughInStock : Exception
{
    public BLThereIsNotEnoughInStock(string messege) : base(messege) { }
}
[Serializable]
public class BlInputNotCorectException : Exception
{
    public BlInputNotCorectException(string massage) : base(massage) { }
    public BlInputNotCorectException(string massage, Exception innerException) : base(massage, innerException) { }
}

