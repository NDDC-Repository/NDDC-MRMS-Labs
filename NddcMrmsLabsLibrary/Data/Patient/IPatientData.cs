using NddcMrmsLabsLibrary.Model.Lab;

namespace NddcMrmsLabsLibrary.Data.Patient
{
    public interface IPatientData
    {
        void AddInvestigation(MyInvestigationModel invest);
        void AddMedicalBio(MyMedicalBioModel medicalBio);
        void AddMedicalReport(MyMedicalReportModel medicalReport);
        void AddRequest(MyRequestModel request);
        void AddVitals(MyVitalsModel vitals);
        List<MyExaminationCategoryModel> AllExaminationCategories();
        List<MyExaminationTypeModel> AllExaminationTypes(int Id);
        List<MyInvestigationModel> AllInvestigations(int empId);
        MyInvestigationModel GetInvestigationDetails(int Id);
        MyMedicalBioModel GetMedicalBio(int empId);
        MyMedicalReportModel GetMedicalReportDetails(int Id);
        List<MyMedicalReportModel> GetMedicalReportList(int empId);
        MyVitalsModel GetVitalDetails(int Id);
        List<MyVitalsModel> GetVitals(int empId);
        void UpdateMedicalReport(MyMedicalReportModel medicalReport);
        void UpdateVital(MyVitalsModel vitals);
    }
}