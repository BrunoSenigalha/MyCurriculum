using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurriculum.Infraestructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAcademicExperienceRepository AcademicExperienceRepository { get; }
        IAddressRepository AddressRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICurriculumRepository CurriculumRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ILinkRepository LinkRepository { get; }
        IProfessionalExpRepository ProfessionalExpRepository { get; }
        IToolRepository ToolRepository { get; }

        void Commit();
    }
}
