using School.Application.DTO;

namespace School.Application.Base.Shared
{
    public static class ExtensionsMethods
    {

        public static IQueryable<StudentDTO> OrderBy(this IQueryable<StudentDTO> soure, OrderType? orderType)
        {
            switch (orderType)
            {
                case OrderType.Name:
                    soure = soure.OrderBy(x => x.Name);
                    break;
                case OrderType.StudId:
                    soure = soure.OrderByDescending(x => x.StudId);
                    break;
                case OrderType.DepName:
                    soure = soure.OrderBy(x => x.DepName);
                    break;
                default:
                    return soure;

            }
            return soure;

        }
    }
}
