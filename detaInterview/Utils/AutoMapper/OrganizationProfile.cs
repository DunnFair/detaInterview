using AutoMapper;
using detaInterview.Models;
using detaInterview.ViewModel;

namespace detaInterview.Utils.AutoMapper
{
    public class OrganizationProfile:Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Detail, DetailViewModel>();
            CreateMap<DetailViewModel, Detail>();
        }
       
    }
}
