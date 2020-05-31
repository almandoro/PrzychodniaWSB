using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Clinic {
    interface IClinic {

        void SetDoctor(string name, string lastName, string specialization);

        void RegisterToDoctor(string name, string lastName, uint age, string disease);

        string DoMedicalAdvice();

        string DoMedicalExamination();

        uint QueTime();

        void GenerateReport();

    }
}
