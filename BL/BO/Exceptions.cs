namespace BO;

[Serializable]
public class BlNotExistException : Exception
{
    public BlNotExistException(string? message) : base(message) { }
    public BlNotExistException(string message, Exception innerException) : base(message, innerException) { }
}

[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string? message) : base(message) { }
    public BlAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}

[Serializable]
public class BlInvalidInputException : Exception
{
    public BlInvalidInputException(string? message) : base(message) { }
    public BlInvalidInputException(string message, Exception innerException) : base(message, innerException) { }
}

[Serializable]
public class BlOperationException : Exception
{
    public BlOperationException(string? message) : base(message) { }
    public BlOperationException(string message, Exception innerException) : base(message, innerException) { }
}
