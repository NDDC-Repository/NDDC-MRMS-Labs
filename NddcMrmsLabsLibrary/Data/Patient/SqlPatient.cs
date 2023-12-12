using NddcMrmsLabsLibrary.Databases;
using NddcMrmsLabsLibrary.Model.Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Data.Patient
{
    public class SqlPatient : IPatientData
    {
        private readonly string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlPatient(ISqlDataAccess db)
        {
            this.db = db;
        }

        //Medical Bio
        public void AddMedicalBio(MyMedicalBioModel medicalBio)
        {
            db.SaveData("Insert Into MedicalBio (EmpId, Height, BloodGroup, Genotype, Weight, BMI, Disabilities, AddedBy, DateAdded) Values(@EmpId, @Height, @BloodGroup, @Genotype, @Weight, @BMI, @Disabilities, @AddedBy, @DateAdded)", new { medicalBio.EmpId, medicalBio.Height, medicalBio.BloodGroup, medicalBio.Genotype, medicalBio.Weight, medicalBio.BMI, medicalBio.Disabilities, medicalBio.AddedBy, medicalBio.DateAdded }, connectionStringName, false);
        }
        public MyMedicalBioModel GetMedicalBio(int empId)
        {
            return db.LoadData<MyMedicalBioModel, dynamic>("Select Top 1 Height, BloodGroup, Genotype, Weight, BMI, Disabilities From MedicalBio Where EmpId = @empId Order By Id DESC", new { empId }, connectionStringName, false).FirstOrDefault();
        }

        //Vitals
        public void AddVitals(MyVitalsModel vitals)
        {
            db.SaveData("Insert Into Vitals (EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy) Values(@EmpId, @Temp, @Pulse, @Oxygen, @Systolic, @Diastolic, @DateAdded, @AddedBy)", new { vitals.EmpId, vitals.Temp, vitals.Pulse, vitals.Oxygen, vitals.Systolic, vitals.Diastolic, vitals.DateAdded, vitals.AddedBy }, connectionStringName, false);
        }
        public MyVitalsModel GetVitalDetails(int Id)
        {
            return db.LoadData<MyVitalsModel, dynamic>("Select Id, EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyVitalsModel> GetVitals(int empId)
        {
            return db.LoadData<MyVitalsModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, EmpId, Temp, Pulse, Oxygen, Systolic, Diastolic, DateAdded, AddedBy From Vitals Where EmpId = @empId Order By Id DESC", new { empId }, connectionStringName, false).ToList();
        }
        public void UpdateVital(MyVitalsModel vitals)
        {
            db.SaveData("Update Vitals Set Temp = @Temp, Pulse = @Pulse, Oxygen = @Oxygen, Systolic = @Systolic, Diastolic = @Diastolic Where Id = @Id", new { vitals.Id, vitals.EmpId, vitals.Temp, vitals.Pulse, vitals.Oxygen, vitals.Systolic, vitals.Diastolic, vitals.DateAdded, vitals.AddedBy }, connectionStringName, false);
        }

        //Investigations
       
        public void AddInvestigation(MyInvestigationModel investDet)
        {
            db.SaveData("Insert Into Investigations (EmpId, ExaminationYear, ExaminationCategoryId, ExaminationTypeId, TestResult, ResultUnit, RefRange, Flag, DateConducted, TimeReported, ConductedBy, Summary, AddedBy, LabId) Values(@EmpId, @ExaminationYear, @ExaminationCategoryId, @ExaminationTypeId, @TestResult, @ResultUnit, @RefRange, @Flag, @DateConducted, @TimeReported, @ConductedBy, @Summary, @AddedBy, @LabId)", new { investDet.EmpId, investDet.ExaminationYear, investDet.ExaminationCategoryId, investDet.ExaminationTypeId, investDet.TestResult, investDet.ResultUnit, investDet.RefRange, investDet.Flag, investDet.DateConducted, investDet.TimeReported, investDet.ConductedBy, investDet.Summary, investDet.AddedBy, investDet.LabId }, connectionStringName, false);
        }
        public List<MyInvestigationModel> AllInvestigations(int empId)
        {
            return db.LoadData<MyInvestigationModel, dynamic>("SELECT Investigations.Id, ROW_NUMBER() OVER (ORDER BY Investigations.Id DESC) As SrNo, Investigations.EmpId, Investigations.ExaminationYear, Investigations.ExaminationTypeId, Investigations.TestResult, Investigations.RefRange, Investigations.Flag, Investigations.ResultUnit, Investigations.DateConducted, ExaminationTypes.ExaminationType FROM Investigations Left JOIN ExaminationTypes ON Investigations.ExaminationTypeId = ExaminationTypes.Id Where Investigations.EmpId = @empId Order By Investigations.Id DESC", new { empId }, connectionStringName, false).ToList();
        }
        public MyInvestigationModel GetInvestigationDetails(int Id)
        {
            return db.LoadData<MyInvestigationModel, dynamic>("SELECT Investigations.Id, Investigations.EmpId, Investigations.ExaminationYear, Investigations.ExaminationTypeId, Investigations.TestResult, Investigations.RefRange, Investigations.Flag, Investigations.ResultUnit, Investigations.DateConducted, Investigations.TimeReported, Investigations.ExaminationCategoryId, Investigations.ExaminationTypeId, Investigations.ConductedBy, Investigations.Summary, ExaminationTypes.ExaminationType FROM Investigations Left JOIN ExaminationTypes ON Investigations.ExaminationTypeId = ExaminationTypes.Id Where Investigations.Id = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyExaminationCategoryModel> AllExaminationCategories()
        {
            return db.LoadData<MyExaminationCategoryModel, dynamic>("SELECT Id, ExaminationCategory From ExaminationCategory ", new { }, connectionStringName, false).ToList();
        }
        public List<MyExaminationTypeModel> AllExaminationTypes(int Id)
        {
            return db.LoadData<MyExaminationTypeModel, dynamic>("SELECT Id, ExaminationType From ExaminationTypes Where ExaminationCategoryId = @Id ", new { Id }, connectionStringName, false).ToList();
        }

        //Medical Reports

        public void AddMedicalReport(MyMedicalReportModel medicalReport)
        {
            //medicalReport.DateAdded = DateTime.Now;
            //medicalReport.AddedBy = "Admin";

            db.SaveData("Insert Into MedicalReport (EmpId, ReportTitle, ExaminationYear, FileName, AddedBy, DateAdded) Values(@EmpId, @ReportTitle, @ExaminationYear, @FileName, @AddedBy, @DateAdded)", new { medicalReport.EmpId, medicalReport.ReportTitle, medicalReport.ExaminationYear, medicalReport.FileName, medicalReport.AddedBy, medicalReport.DateAdded }, connectionStringName, false);
        }
        public MyMedicalReportModel GetMedicalReportDetails(int Id)
        {
            return db.LoadData<MyMedicalReportModel, dynamic>("Select EmpId, ReportTitle, ExaminationYear, FileName From MedicalReport Where EmpId = @Id", new { Id }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyMedicalReportModel> GetMedicalReportList(int empId)
        {
            return db.LoadData<MyMedicalReportModel, dynamic>("Select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, EmpId, Id, ReportTitle, ExaminationYear, FileName From MedicalReport Where EmpId = @empId Order By Id DESC", new { empId }, connectionStringName, false).ToList();
        }
        public void UpdateMedicalReport(MyMedicalReportModel medicalReport)
        {
            db.SaveData("Update MedicalReport Set ReportTitle = @ReportTitle, ExaminationYear = @ExaminationYear, FileName = @FileName", new { medicalReport.ReportTitle, medicalReport.ExaminationYear, medicalReport.FileName }, connectionStringName, false);
        }

        //Requests
        public void AddRequest(MyRequestModel request)
        {
            //medicalReport.DateAdded = DateTime.Now;
            //medicalReport.AddedBy = "Admin";

            db.SaveData("Insert Into Requests (InvestigationId, UserName, RequestType, RequestedBy, RequestedFrom, ExaminationYear, ExaminationCategoryId, ExaminationTypeId, Result, ResultUnit, RefRange, Flag, DateConducted, TimeReportedOn, Summary, DateRequested) Values(@InvestigationId, @UserName, @RequestType, @RequestedBy, @RequestedFrom, @ExaminationYear, @ExaminationCategoryId, @ExaminationTypeId, @Result, @ResultUnit, @RefRange, @Flag, @DateConducted, @TimeReportedOn, @Summary, @DateRequested)", new { request.InvestigationId, request.UserName, request.RequestType, request.RequestedBy, request.RequestedFrom, request.ExaminationYear, request.ExaminationCategoryId, request.ExaminationTypeId, request.Result, request.ResultUnit, request.RefRange, request.Flag, request.DateConducted, request.TimeReportedOn, request.Summary, request.DateRequested }, connectionStringName, false);
        }

    }
}
