using AutoMapper;
using LeaveManagementSystem.Web.Models.Periods;

namespace LeaveManagementSystem.Web.MappingProfiles
{
    public class PeriodAutoMapperProfile : Profile
    {
        public PeriodAutoMapperProfile()
        {
            #region Periods
            CreateMap<Period, PeriodsReadOnlyVM>();
            CreateMap<PeriodCreateVM, Period>();
            CreateMap<PeriodEditVM, Period>().ReverseMap();
            #endregion
        }
    }
}
