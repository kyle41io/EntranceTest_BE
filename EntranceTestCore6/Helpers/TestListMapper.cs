using AutoMapper;
using EntranceTestCore6.Data;
using EntranceTestCore6.Models;

public class TestListProfile : Profile
{
    public TestListProfile()
    {
        CreateMap<Test, TestModel>()
            .ForMember(dest => dest.TestName, opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.TestTime, opt => opt.MapFrom(src => src.TestTime))
            .ForMember(dest => dest.TestDesc, opt => opt.MapFrom(src => src.TestDesc));
        CreateMap<TestModel, Test>()
            .ForMember(dest => dest.TestName, opt => opt.MapFrom(src => src.TestName))
            .ForMember(dest => dest.TestTime, opt => opt.MapFrom(src => src.TestTime))
            .ForMember(dest => dest.TestDesc, opt => opt.MapFrom(src => src.TestDesc));
    }
}