using NddcMrmsLabsLibrary.Model.Lab;

namespace NddcMrmsLabsLibrary.Data.Patient
{
    public interface IPatientData
    {
        void AddInvestigation(MyInvestigationModel invest);
        void AddMedicalBio(MyMedicalBioModel medicalBio);
        void AddVitals(MyVitalsModel vitals);
        List<MyExaminationCategoryModel> AllExaminationCategories();
        List<MyExaminationTypeModel> AllExaminationTypes(int Id);
        List<MyInvestigationModel> AllInvestigations(int empId);
        MyMedicalBioModel GetMedicalBio(int empId);
        MyVitalsModel GetVitalDetails(int Id);
        List<MyVitalsModel> GetVitals(int empId);
        void UpdateVital(MyVitalsModel vitals);
    }
}