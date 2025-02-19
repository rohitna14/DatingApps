using System;

namespace API.Errors;

public class ApiException(int StatusCode, string message, string? details)
{
public int StatusCode { get; set; } = StatusCode;

public string Message { get; set; } = message;

public string? details { get; set; } = details;
}
