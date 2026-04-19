<<<<<<< HEAD
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
=======
﻿namespace BO;

[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }

    public BlDoesNotExistException(string message, Exception innerException)
        : base(message, innerException) { }
>>>>>>> f44864669003981d2982c478576812a2ba3074fb
}

[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string? message) : base(message) { }

    public BlAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlInvalidInputException : Exception
{
    public BlInvalidInputException(string? message) : base(message) { }

    public BlInvalidInputException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlGeneralException : Exception
{
    public BlGeneralException(string? message) : base(message) { }

    public BlGeneralException(string message, Exception innerException)
        : base(message, innerException) { }
}


