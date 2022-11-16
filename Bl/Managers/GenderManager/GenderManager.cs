using AutoMapper;
using ECommerceGP.DAL;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceGP.Bl
{
    public class GenderManager : IGenderManager
    {
        private readonly IGenderRepo _genderRepo;
        private readonly IMapper _imapper;
        public GenderManager(IGenderRepo genderRepo,IMapper mapper)
        {
            _genderRepo = genderRepo;
            _imapper = mapper;
        }
        public void AddGender(GenderDtosWrite genderdto)
        {
            var dbGender = _imapper.Map<Gender>(genderdto);
            _genderRepo.Add(dbGender);
            _genderRepo.SaveChanges();
            //return _imapper.Map<GenderDtosRead>(dbGender);

        }

        public void DeleteGender(int id)
        {
            var genderByid = _genderRepo.GetById(id);
            if (genderByid == null) return; 
            _genderRepo.Delete(genderByid);
            _genderRepo.SaveChanges();
        }

        //public bool EditGender(GenderDtosWrite gender)
        //{
        //    var GenderById = _genderRepo.GetById(gender.Genderid);
        //    if(GenderById == null) return false;
        //    _imapper.Map(gender,GenderById);
        //    _genderRepo.SaveChanges();
        //    return true;
        //}

        public List<GenderDtosRead> GetAllGender()
        {
            var genders = _genderRepo.GetAll();
            var genderList = _imapper.Map<List<GenderDtosRead>>(genders);
            return genderList;
        }

        public GenderDtosRead? GetGenderById(int id)
        {
            var genderById =_genderRepo.GetById(id);
            if (genderById == null)
                return null;
            return _imapper.Map<GenderDtosRead>(genderById);
        }
    }
}
