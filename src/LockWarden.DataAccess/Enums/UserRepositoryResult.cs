using System;

public enum CreateUserRepository
{
    Success,
    Exists,
    InvalidLogin,
}
public enum GetUserResult
{
	Success,
	NotFound,
	InvalidPassword,
}
public enum GetInfoUserResult
{
    Success,
    NotFound,
}
public enum UpdateUserResult
{
	Success,
	NotFound,
	InvalidLogin,
}
public enum DeleteUserResult
{
	Success,
	NotFound,
}
