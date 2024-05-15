namespace School.Application.Base.Shared
{

    public enum StatusResult
    {
        Falid,
        Success,
        Exist,
        NotExists,
        ApplicationException,
        ValidationException,

    }
    public enum OrderType
    {
        Name,
        StudId,
        DepName
    }
    public enum Language
    {
        english,
        arabic

    }
}
