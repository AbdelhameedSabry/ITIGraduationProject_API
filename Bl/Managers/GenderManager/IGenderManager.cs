namespace ECommerceGP.Bl
{
    public interface IGenderManager
    {
        List<GenderDtosRead> GetAllGender();
        GenderDtosRead? GetGenderById(int id);
        //GenderDtosRead?AddGender(GenderDtosWrite gender);
        void AddGender(GenderDtosWrite gender);
        //bool EditGender(GenderDtosWrite gender);
        void DeleteGender(int id);  
    }
}
