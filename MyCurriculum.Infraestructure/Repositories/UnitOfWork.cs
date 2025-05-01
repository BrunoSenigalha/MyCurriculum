using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurriculum.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAcademicExperienceRepository academicExperienceRepository;

        private IAddressRepository addressRepository;

        private ICourseRepository courseRepository;

        private ICurriculumRepository curriculumRepository;

        private ILanguageRepository languageRepository;

        private IProjectRepository projectRepository;

        private ILinkRepository linkRepository;

        private IProfessionalExpRepository professionalExpRepository;

        private IToolRepository toolRepository;

        public EntitiesContext _context;

        public UnitOfWork(EntitiesContext context)
        {
            _context = context;
        }

        public IAcademicExperienceRepository AcademicExperienceRepository
        {
            get
            {
                //return academicExperienceRepository ?? new AcademicExperienceRepository(_context);
                if (academicExperienceRepository == null)
                {
                    academicExperienceRepository = new AcademicExperienceRepository(_context);
                }

                return academicExperienceRepository;
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                return addressRepository ?? new AddressRepository(_context);
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                return courseRepository ?? new CourseRepository(_context);
            }
        }

        public ICurriculumRepository CurriculumRepository
        {
            get
            {
                return curriculumRepository ?? new CurriculumRepository(_context);
            }
        }

        public ILanguageRepository LanguageRepository
        {
            get
            {
                return languageRepository ?? new LanguageRepository(_context);
            }
        }

        public ILinkRepository LinkRepository
        {
            get
            {
                return linkRepository ?? new LinkRepository(_context);
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                return projectRepository ?? new ProjectRepository(_context);
            }
        }

        public IProfessionalExpRepository ProfessionalExpRepository
        {
            get
            {
                return professionalExpRepository ?? new ProfessionalExpRepository(_context);
            }
        }

        public IToolRepository ToolRepository
        {
            get
            {
                return toolRepository ?? new ToolRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
