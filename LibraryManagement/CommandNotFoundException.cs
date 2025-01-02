using System;

namespace LibraryManagement.Exceptions;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException(string commandName)
        : base($"Command '{commandName}' not found.")
    {
    }
}
